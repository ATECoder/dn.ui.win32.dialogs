using System.Diagnostics;
using System.Runtime.InteropServices;
using cc.isr.Win32.Native;

namespace cc.isr.Win32.Dialogs;

/// <summary>   Dialog for selecting files. </summary>
/// <remarks>   2025-10-15. </remarks>
public class FilePickerDialog : IDisposable
{
    #region " construction and disposal "

    /// <summary>   Default constructor. </summary>
    /// <remarks>   2025-10-15. </remarks>
    public FilePickerDialog()
    {
        // Initialization of the COM object (RCW)
        this.Dialog = ( IFileOpenDialog ) new FileOpenDialogRCW();

        this.FileName = string.Empty;

        // Set the default filer
        this._fileTypes = [new COMDLG_FILTERSPEC { pszName = "All Files (*.*)", pszSpec = "*.*" }];
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
    /// resources.
    /// </summary>
    /// <remarks>   2025-10-15. </remarks>
    public void Dispose()
    {
        this.Dispose( true );

        // This object will be cleaned up by the Dispose method.
        // Calling GC.SuppressFinalize to take this object off the finalization queue 
        // and prevent the finalizer from executing a second time.
        GC.SuppressFinalize( this );
    }

    private bool _disposed;
    /// <summary>
    /// Releases the unmanaged resources used by the FilePickerDialog and optionally releases the
    /// managed resources.
    /// </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <param name="disposing">    True to release both managed and unmanaged resources; false to
    ///                             release only unmanaged resources. </param>
    protected virtual void Dispose( bool disposing )
    {
        if ( !this._disposed )
        {
            if ( disposing )
            {
                // Dispose managed resources (none in this case)
            }

            // Release the unmanaged COM resource (the IFileOpenDialog RCW)
            if ( this.Dialog != null )
            {
                try
                {
                    // Call FinalReleaseComObject to ensure the RCW is released
                    _ = Marshal.FinalReleaseComObject( this.Dialog );
                }
                catch
                {
                    // Ignore exceptions during final release
                }
                this.Dialog = null;
            }

            this._disposed = true;
        }
    }

    /// <summary>
    /// A finalizer is generally not recommended unless you are certain you have unmanaged resources
    /// that must be freed, and even then, only to catch cases where Dispose was not called.
    /// </summary>
    /// <remarks>   2025-10-15. </remarks>
    ~FilePickerDialog()
    {
        this.Dispose( false );
    }

    #endregion

    #region " show dialog "

#if false
    // for WPF support
    public bool? ShowDialog( Window owner = null, bool throwOnError = false )
    {
        owner = owner ?? Application.Current?.MainWindow;
        return ShowDialog( owner != null ? new WindowInteropHelper( owner ).Handle : IntPtr.Zero, throwOnError );
    }
#endif

    /// <summary>   Shows the dialog. </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <returns>   A bool? </returns>
    public virtual bool ShowDialog()
    {
        return this.ShowDialog( IntPtr.Zero, out _, true );
    }

    /// <summary>   Shows the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="details">      [out] provides information in case the method returns false. </param>
    /// <param name="throwOnError"> (Optional) True to throw on error. </param>
    /// <returns>   A bool? </returns>
    public bool ShowDialog( out string details, bool throwOnError = false )
    {
        return this.ShowDialog( IntPtr.Zero, out details, throwOnError );
    }

    /// <summary>   Shows the dialog. </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <exception cref="ObjectDisposedException">      Thrown when a supplied object has been
    ///                                                 disposed. </exception>
    /// <exception cref="InvalidOperationException">    Thrown when the requested operation is
    ///                                                 invalid. </exception>
    /// <exception cref="COMException">                 Thrown when an unrecognized hResult is
    ///                                                 returned from a COM method call. </exception>
    /// <param name="owner">        The owner. </param>
    /// <param name="details">      [out] The details. </param>
    /// <param name="throwOnError"> (Optional) True to throw on error. </param>
    /// <returns>   True if it succeeds, false if it fails. </returns>
    public bool ShowDialog( IntPtr owner, out string details, bool throwOnError = false )
    {
#if NET6_0_OR_GREATER
        ObjectDisposedException.ThrowIf( this._disposed, nameof( FilePickerDialog ) );
#else
        if ( this._disposed ) throw new ObjectDisposedException( nameof( FilePickerDialog ) );
#endif
        if ( this.Dialog is null ) throw new InvalidOperationException( "The underlying COM object wrapper was disposed." );

        bool success = false;
        try
        {
            // Get the basic options
            _ = this.Dialog.GetOptions( out FOS options );

            // apply the options
            options = this.SetOptions( options );

            _ = this.Dialog.SetOptions( options );

            // Set the title
            if ( !string.IsNullOrWhiteSpace( this.Title ) )
                _ = this.Dialog.SetTitle( this.Title );

            if ( this.OkButtonLabel is not null && !string.IsNullOrWhiteSpace( this.OkButtonLabel ) )
                _ = this.Dialog.SetOkButtonLabel( this.OkButtonLabel );

            if ( this.InitialFileName is not null && !string.IsNullOrWhiteSpace( this.InitialFileName ) )
                _ = this.Dialog.SetFileName( this.InitialFileName );

            // --- Set File Types (Filters) ---
            if ( this._fileTypes is not null && this._fileTypes.Length > 0 )
                _ = this.Dialog.SetFileTypes( ( uint ) this._fileTypes.Length, this._fileTypes );

            if ( owner == IntPtr.Zero )
                owner = Process.GetCurrentProcess().MainWindowHandle;

            if ( owner == IntPtr.Zero )
                owner = NativeMethods.GetDesktopWindow();

            // set the initial directory
            FilePickerDialog.SetInitialDirectory( this.Dialog, this.InitialDirectory, true, out details );

            // Show the dialog
            int returnCode = this.Dialog.Show( owner );

            if ( returnCode == NativeMethods.ERROR_CANCELLED )
            {
                details = "The dialog was cancelled by the user.";
                return false;
            }

            if ( 0 != NativeMethods.CheckReturnCode( returnCode, throwOnError, out details ) )
                return false;

            // retrieve results

            this.FileNames = null;
            this.FileName = null;
            if ( this.MultiSelect )
            {
                success = GetMultiResults( this.Dialog, out IList<string> fileList );
                if ( success )
                {
                    this.FileNames = [.. fileList];
                    this.FileName = this.FileNames.FirstOrDefault<string>();
                }
            }
            else
            {
                // Existing single-select logic
                success = GetSingleResult( this.Dialog, out string? path );
                if ( success )
                {
                    this.FileName = path;
                    this.FileNames = [path ?? ""];
                }
            }
#if false
            _ = this._dialog.GetResult( out IShellItem selectedItem );

            if ( selectedItem != null )
            {
                try
                {
                    // Get the file system path
                    _ = selectedItem.GetDisplayName( SIGDN.SIGDN_FILESYSPATH, out string fileName );
                    this.FileName = fileName;
                    success = true;
                }
                finally
                {
                    // Release the IShellItem reference
                    _ = Marshal.ReleaseComObject( selectedItem );
                }
#endif
        }
        catch ( COMException )
        {
            // Handle specific COM exceptions if necessary, but re-throwing is often sufficient.
            // For example, E_CANCEL (0x800704C7) is expected if the user cancels.
            throw;
        }
        finally
        {
            // the COM object is disposed
            // if ( this._dialog != null ) _ = Marshal.FinalReleaseComObject( this._dialog );
        }

        return success;
    }

    #endregion

    #region " Fields "

    /// <summary>   Gets the dialog. </summary>
    /// <value> The dialog. </value>
    internal IFileOpenDialog? Dialog { get; private set; }

    /// <summary>   Gets or sets the filename of the file. </summary>
    /// <value> The name of the file. </value>
    public string? FileName { get; private set; }

    /// <summary>   Gets or sets a list of names of the files. </summary>
    /// <value> A list of names of the files. </value>
    public string[]? FileNames { get; private set; }

    /// <summary>   Gets or sets a value indicating whether the multi select. </summary>
    /// <value> True if multi select, false if not. </value>
    public bool MultiSelect { get; set; }

    /// <summary>   Gets or sets the title. </summary>
    /// <value> The title. </value>
    public string Title { get; set; } = "Select a File";

    /// <summary>   List of types of the files. </summary>
    private COMDLG_FILTERSPEC[] _fileTypes;

    /// <summary>   Gets or sets the pathname of the initial directory. </summary>
    /// <value> The pathname of the initial directory. </value>
    public string? InitialDirectory { get; set; }

    /// <summary>   Gets or sets a value indicating whether the path must exist. </summary>
    /// <value> True if path must exist, false if not. </value>
    public bool PathMustExist { get; set; } = true;

    /// <summary>   Gets or sets a value indicating whether the file must exist. </summary>
    /// <value> True if file must exist, false if not. </value>
    public bool FileMustExist { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the file system should be forced.
    /// </summary>
    /// <value> True if force file system, false if not. </value>
    public virtual bool ForceFileSystem { get; set; }

    /// <summary>   Gets or sets the ok button label. </summary>
    /// <value> The ok button label. </value>
    public string? OkButtonLabel { get; set; }

    /// <summary>   Gets or sets the initial file name. </summary>
    /// <value> The initial file name. </value>
    public string? InitialFileName { get; set; }

    #endregion

    #region " public methods "

    /// <summary>   Adds a file type consisting of a name and a pattern. </summary>
    /// <remarks>   2025-10-15. <para> 
    /// Name, Pattern examples: </para><para>
    ///    { "JPG", "*.jpg;*.jpeg" }     </para><para>
    ///    { "BMP", "*.bmp" }            </para><para>
    ///    { "c# source files", "*.cs" } </para><para>
    ///    { "Test Files", "*.txt" }     </para><para>
    ///    { "All Files", "*.*" }        </para></remarks>
    /// <param name="name">     The name. </param>
    /// <param name="pattern">  Specifies the pattern. </param>
    public void AddFileType( string name, string pattern )
    {
        if ( this._fileTypes == null )
        {
            this._fileTypes = [new COMDLG_FILTERSPEC() { pszName = name, pszSpec = pattern }];
        }
        else
        {
            int oldLength = this._fileTypes.Length;
            Array.Resize( ref this._fileTypes, oldLength + 1 );
            this._fileTypes[oldLength] = new COMDLG_FILTERSPEC() { pszName = name, pszSpec = pattern };
        }
    }

    #endregion

    #region " helper methods "

    /// <summary>   Sets the options. </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <param name="options">  Options for controlling the operation. </param>
    /// <returns>   The updated options. </returns>
    private FOS SetOptions( FOS options )
    {
        return ( FOS ) this.SetOptions( ( int ) options );
    }

    /// <summary>   Sets the options. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="options">  Options for controlling the operation. </param>
    /// <returns>   The updated options. </returns>
    protected virtual int SetOptions( int options )
    {
        if ( this.PathMustExist )
            options |= ( int ) FOS.FOS_PATHMUSTEXIST;
        else
            options &= ~( int ) FOS.FOS_PATHMUSTEXIST;

        if ( this.FileMustExist )
            options |= ( int ) FOS.FOS_FILEMUSTEXIST;
        else
            options &= ~( int ) FOS.FOS_FILEMUSTEXIST;

        if ( this.ForceFileSystem )
            options |= ( int ) FOS.FOS_FORCEFILESYSTEM;
        else
            options &= ~( int ) FOS.FOS_FORCEFILESYSTEM;

        // Apply MultiSelect option
        if ( this.MultiSelect )
            options |= ( int ) FOS.FOS_ALLOWMULTISELECT;
        else
            options &= ~( int ) FOS.FOS_ALLOWMULTISELECT;

        return options;
    }

    /// <summary>   Helper method for single-select (moved existing logic here) </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <param name="dialog">   The dialog. </param>
    /// <param name="path">     [out] Full pathname of the file. </param>
    /// <returns>   True if it succeeds, false if it fails. </returns>
    private static bool GetSingleResult( IFileOpenDialog? dialog, out string? path )
    {
        path = null;
        if ( dialog is null ) return false;

        IShellItem? selectedItem = null;
        try
        {
            if ( dialog is null )
                return false;
            else
            {
                _ = dialog.GetResult( out selectedItem );

                if ( selectedItem != null )
                    return FilePickerDialog.ExtractFilePath( selectedItem, out path );
            }
        }
        finally
        {
            if ( selectedItem != null )
                _ = Marshal.ReleaseComObject( selectedItem );
        }
        return false;
    }

    /// <summary>   New helper method for multi-select. </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <param name="dialog">   The dialog. </param>
    /// <param name="fileList"> [out] List of files. </param>
    /// <returns>   True if it succeeds, false if it fails. </returns>
    private static bool GetMultiResults( IFileOpenDialog? dialog, out IList<string> fileList )
    {
        fileList = [];
        if ( dialog is null ) return false;

        IShellItemArray? shellItemArray = null;

        try
        {
            // IFileOpenDialog.GetResults
            _ = dialog.GetResults( out shellItemArray );

            _ = shellItemArray.GetCount( out int count );

            for ( int i = 0; i < count; i++ )
            {
                IShellItem? item = null;
                try
                {
                    _ = shellItemArray.GetItemAt( i, out item );
                    if ( FilePickerDialog.ExtractFilePath( item, out string? path ) )
                    {
                        fileList.Add( path );
                    }
                }
                finally
                {
                    if ( item != null )
                        _ = Marshal.ReleaseComObject( item );
                }
            }

            return fileList.Count > 0;
        }
        finally
        {
            if ( shellItemArray != null )
                _ = Marshal.ReleaseComObject( shellItemArray );
        }
    }

    /// <summary>   Helper to extract the path from an IShellItem. </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <param name="item"> The item. </param>
    /// <param name="path"> [out] Full pathname of the file. </param>
    /// <returns>   True if it succeeds, false if it fails. </returns>
    private static bool ExtractFilePath( IShellItem item, out string path )
    {
#if true
        _ = item.GetDisplayName( SIGDN.SIGDN_FILESYSPATH, out path );
        return true;
#else
        IntPtr pszFilePath = IntPtr.Zero;
        path = null;
        try
        {
            _ = item.GetDisplayName( SIGDN.SIGDN_FILESYSPATH, out pszFilePath );
            path = Marshal.PtrToStringAuto( pszFilePath );
            return true;
        }
        finally
        {
            if ( pszFilePath != IntPtr.Zero )
                Marshal.FreeCoTaskMem( pszFilePath );
        }
#endif
    }

    /// <summary>   Sets initial directory. </summary>
    /// <remarks>   2025-10-15. </remarks>
    /// <param name="dialog">           The dialog. </param>
    /// <param name="initialDirectory"> The pathname of the initial directory. </param>
    /// <param name="throwOnError">     True to throw on error. </param>
    /// <param name="details">          [out] provides information in case the method returns false. </param>
    /// <returns>   True if it succeeds, false if it fails. </returns>
    internal static bool SetInitialDirectory( IFileOpenDialog dialog, string? initialDirectory, bool throwOnError, out string details )
    {
        details = string.Empty;
        if ( initialDirectory is not null && !string.IsNullOrEmpty( initialDirectory ) )
        {
            IShellItem? initialFolder = null;
            try
            {
                int returnCode = NativeMethods.SHCreateItemFromParsingName( initialDirectory, null,
                    typeof( IShellItem ).GUID, out initialFolder );

                if ( 0 != NativeMethods.CheckReturnCode( NativeMethods.SHCreateItemFromParsingName( initialDirectory, null,
                    typeof( IShellItem ).GUID, out IShellItem? item ), throwOnError, out details ) )
                {
                    details = $"Failed to get folder for the path '{initialDirectory}':\n\t{details}.";
                    return false;
                }

                _ = dialog.SetFolder( initialFolder );
            }
            catch ( Exception )
            {
                // Ignore path conversion errors and let the dialog default
            }
            finally
            {
                if ( initialFolder != null )
                    Marshal.ReleaseComObject( initialFolder );
            }
        }
        return true;

#if false
        // --- NEW: Set Initial Directory ---
        if ( !string.IsNullOrEmpty( InitialDirectory ) && System.IO.Directory.Exists( InitialDirectory ) )
        {
            IShellItem initialFolder = null;
            try
            {
                // Convert path string to IShellItem
                int hr = NativeMethods.SHCreateItemFromParsingName(
                    InitialDirectory,
                    IntPtr.Zero,
                    new Guid( Native.NativeGuids.I_SHELL_ITEM_IID ),
                    out initialFolder );

                if ( hr == 0 && initialFolder != null ) // S_OK
                {
                    // Use SetFolder to guarantee the directory is opened
                    dialog.SetFolder( initialFolder );
                    // Alternatively, use SetDefaultFolder if you want the dialog to fall 
                    // back to the user's last location if they recently used the dialog.
                }
            }
            catch ( Exception )
            {
                // Ignore path conversion errors and let the dialog default
            }
            finally
            {
                if ( initialFolder != null )
                    Marshal.ReleaseComObject( initialFolder );
            }
#endif

    }
    #endregion
}
