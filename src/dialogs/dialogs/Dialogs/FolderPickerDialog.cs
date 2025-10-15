using System.Diagnostics;
using System.Runtime.InteropServices;
using cc.isr.Win32.Native;

namespace cc.isr.Win32.Dialogs;

/// <summary>   A folder picker dialog. </summary>
/// <remarks>
/// 2025-10-09. <para>
/// <see href="https://stackoverflow.com/questions/11624298/how-do-i-use-openfiledialog-to-select-a-folder"/>
/// </para>
/// </remarks>
public class FolderPickerDialog
{
    private readonly List<string> _pathNames = [];
    /// <summary>   Gets the returned paths. </summary>
    /// <value> The returned paths. </value>
    public IReadOnlyList<string> PathNames => this._pathNames;

    /// <summary>   Gets the full pathname of the first selected <see cref="PathNames"/>. </summary>
    /// <value> The full pathname of the first selected <see cref="PathNames"/>. </value>
    public string PathName => this.PathNames.Any() ? this.PathNames[0] : string.Empty;

    private readonly List<string> _fullNames = [];
    /// <summary>   Gets a list of full names. </summary>
    /// <value> A list of full names. </value>
    public IReadOnlyList<string> FullNames => this._fullNames;

    /// <summary>   Gets the full name of the first selected <see cref="FullNames"/>. </summary>
    /// <value> The full name of the first selected <see cref="FullNames"/>. </value>
    public string FullName => this.FullNames.Any() ? this.FullNames[0] : string.Empty;

    /// <summary>   Gets or sets the pathname of the initial directory. </summary>
    /// <value> The pathname of the initial directory. </value>
    public virtual required string InitialDirectory { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the file system should be forced.
    /// </summary>
    /// <value> True if force file system, false if not. </value>
    public virtual bool ForceFileSystem { get; set; }

    /// <summary>   Gets or sets a value indicating whether the selecting multiple folders is allowed. </summary>
    /// <value> True if multi select, false if not. </value>
    public virtual bool MultiSelect { get; set; }

    /// <summary>   Gets or sets the title. </summary>
    /// <value> The title. </value>
    public virtual required string Title { get; set; }

    /// <summary>   Gets or sets the ok button label. </summary>
    /// <value> The ok button label. </value>
    public virtual required string OkButtonLabel { get; set; }

    /// <summary>   Gets or sets the initial folder name. </summary>
    /// <value> The initial folder name. </value>
    public virtual required string InitialFolderName { get; set; }

    /// <summary>   Sets the options. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="options">  Options for controlling the operation. </param>
    /// <returns>   The updated options. </returns>
    protected virtual int SetOptions( int options )
    {
        if ( this.ForceFileSystem )
            options |= ( int ) FOS.FOS_FORCEFILESYSTEM;
        else
            options &= ~( int ) FOS.FOS_FORCEFILESYSTEM;

        if ( this.MultiSelect )
            options |= ( int ) FOS.FOS_ALLOWMULTISELECT;
        else
            options &= ~( int ) FOS.FOS_ALLOWMULTISELECT;

        return options;
    }

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

    /// <summary>   Shows the folder picker dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="owner">        The owner. </param>
    /// <param name="details">      [out] provides information in case the method returns false. </param>
    /// <param name="throwOnError"> (Optional) True to throw on error. </param>
    /// <returns>   A boolean. </returns>
    public virtual bool ShowDialog( IntPtr owner, out string details, bool throwOnError = false )
    {
        IFileOpenDialog dialog = ( IFileOpenDialog ) new FileOpenDialog();
        if ( !string.IsNullOrEmpty( this.InitialDirectory ) )
        {
            IShellItem? item = null;
            try
            {
                if ( 0 != NativeMethods.CheckReturnCode( NativeMethods.SHCreateItemFromParsingName( this.InitialDirectory, null,
                    typeof( IShellItem ).GUID, out item ), throwOnError, out details ) )
                {
                    details = $"Failed to get folder for the path '{this.InitialDirectory}':\n\t{details}.";
                    return false;
                }

                _ = dialog.SetFolder( item );
            }
            catch ( Exception )
            {
                throw;
            }
            finally
            {
                if ( item != null )
                    _ = Marshal.ReleaseComObject( item );
            }
        }

        FOS options = FOS.FOS_PICKFOLDERS;
        options = ( FOS ) this.SetOptions( ( int ) options );
        _ = dialog.SetOptions( options );

        if ( !string.IsNullOrWhiteSpace( this.Title ) )
            _ = dialog.SetTitle( this.Title );

        if ( !string.IsNullOrWhiteSpace( this.OkButtonLabel ) )
            _ = dialog.SetOkButtonLabel( this.OkButtonLabel );

        if ( !string.IsNullOrWhiteSpace( this.InitialFolderName ) )
            _ = dialog.SetFileName( this.InitialFolderName );

        if ( owner == IntPtr.Zero )
            owner = Process.GetCurrentProcess().MainWindowHandle;

        if ( owner == IntPtr.Zero )
            owner = NativeMethods.GetDesktopWindow();

        int returnCode = dialog.Show( owner );
        if ( returnCode == NativeMethods.ERROR_CANCELLED )
        {
            details = "The folder selection was cancelled by the user.";
            return false;
        }

        if ( 0 != NativeMethods.CheckReturnCode( returnCode, throwOnError, out details ) )
            return false;

        IShellItemArray? items = null;
        try
        {
            if ( 0 != NativeMethods.CheckReturnCode( dialog.GetResults( out items ), throwOnError, out details ) )
                return false;

            _ = items.GetCount( out int count );
            for ( int i = 0; i < count; i++ )
            {
                string? path = null;
                string? name = null;
                IShellItem? item = null;
                try
                {
                    _ = items.GetItemAt( i, out item );
                    _ = NativeMethods.CheckReturnCode( item.GetDisplayName( SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out path ), throwOnError, out string _ );
                    _ = NativeMethods.CheckReturnCode( item.GetDisplayName( SIGDN.SIGDN_DESKTOPABSOLUTEEDITING, out name ), throwOnError, out string _ );
                }
                catch ( Exception )
                {
                    throw;
                }
                finally
                {
                    if ( items != null )
                        _ = Marshal.ReleaseComObject( items );
                }
                if ( path is not null && name is not null )
                {
                    this._pathNames.Add( path );
                    this._fullNames.Add( name );
                }
            }
        }
        catch ( Exception )
        {
            throw;
        }
        finally
        {
            if ( items != null )
                _ = Marshal.ReleaseComObject( items );
        }
        details = string.Empty;
        return true;
    }
}
