using System.Diagnostics;
using cc.isr.Win32.Native;

namespace cc.isr.Win32.Dialogs;

/// <summary>   A folder picker. </summary>
/// <remarks>
/// 2025-10-09. <para>
/// <see href="https://stackoverflow.com/questions/11624298/how-do-i-use-openfiledialog-to-select-a-folder"/>
/// </para>
/// </remarks>
public class FolderPicker
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

    /// <summary>   Gets or sets the full pathname of the input file. </summary>
    /// <value> The full pathname of the input file. </value>
    public virtual required string InputPath { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the file system should be forced.
    /// </summary>
    /// <value> True if force file system, false if not. </value>
    public virtual bool ForceFileSystem { get; set; }

    /// <summary>   Gets or sets a value indicating whether the multiselect. </summary>
    /// <value> True if multiselect, false if not. </value>
    public virtual bool Multiselect { get; set; }

    /// <summary>   Gets or sets the title. </summary>
    /// <value> The title. </value>
    public virtual required string Title { get; set; }
    /// <summary>   Gets or sets the ok button label. </summary>
    /// <value> The ok button label. </value>
    public virtual required string OkButtonLabel { get; set; }
    /// <summary>   Gets or sets the file name label. </summary>
    /// <value> The file name label. </value>
    public virtual required string FileNameLabel { get; set; }

    /// <summary>   Sets the options. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="options">  Options for controlling the operation. </param>
    /// <returns>   An int. </returns>
    protected virtual int SetOptions( int options )
    {
        if ( this.ForceFileSystem )
        {
            options |= ( int ) FOS.FOS_FORCEFILESYSTEM;
        }

        if ( this.Multiselect )
        {
            options |= ( int ) FOS.FOS_ALLOWMULTISELECT;
        }
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
        if ( !string.IsNullOrEmpty( this.InputPath ) )
        {
            if ( 0 != NativeMethods.CheckReturnCode( NativeMethods.SHCreateItemFromParsingName( this.InputPath, null,
                typeof( IShellItem ).GUID, out IShellItem? item ), throwOnError, out details ) )
            {
                details = $"Failed to get folder for the path '{this.InputPath}':\n\t{details}.";
                return false;
            }

            _ = dialog.SetFolder( item );
        }

        FOS options = FOS.FOS_PICKFOLDERS;
        options = ( FOS ) this.SetOptions( ( int ) options );
        _ = dialog.SetOptions( options );

        if ( !string.IsNullOrWhiteSpace( this.Title ) )
            _ = dialog.SetTitle( this.Title );

        if ( !string.IsNullOrWhiteSpace( this.OkButtonLabel ) )
            _ = dialog.SetOkButtonLabel( this.OkButtonLabel );

        if ( !string.IsNullOrWhiteSpace( this.FileNameLabel ) )
            _ = dialog.SetFileName( this.FileNameLabel );

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

        if ( NativeMethods.CheckReturnCode( returnCode, throwOnError, out details ) != 0 )
            return false;

        if ( NativeMethods.CheckReturnCode( dialog.GetResults( out IShellItemArray? items ), throwOnError, out details ) != 0 )
            return false;

        _ = items.GetCount( out int count );
        for ( int i = 0; i < count; i++ )
        {
            _ = items.GetItemAt( i, out IShellItem? item );
            _ = NativeMethods.CheckReturnCode( item.GetDisplayName( SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out string? path ), throwOnError, out string _ );
            _ = NativeMethods.CheckReturnCode( item.GetDisplayName( SIGDN.SIGDN_DESKTOPABSOLUTEEDITING, out string? name ), throwOnError, out string _ );
            if ( path is not null && name is not null )
            {
                this._pathNames.Add( path );
                this._fullNames.Add( name );
            }
        }
        details = string.Empty;
        return true;
    }
}
