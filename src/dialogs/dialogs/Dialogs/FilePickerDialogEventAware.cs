using System.Runtime.InteropServices;

namespace cc.isr.Win32.Dialogs;

/// <summary>   A file picker dialog event aware. </summary>
/// <remarks>   2025-10-15. </remarks>
internal class FilePickerDialogEventAware : FilePickerDialog
{
    private uint _eventCookie;
    private readonly FileDialogEventHandler _eventHandler;

    /// <summary>   A public event the user of the class can subscribe to. </summary>
    public event Action<string> FolderChanged;

    /// <summary>   Default constructor. </summary>
    /// <remarks>   2025-10-15. </remarks>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public FilePickerDialogEventAware() : base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        // Initialize the event handler and link it to the public event
        this._eventHandler = new FileDialogEventHandler();
        this._eventHandler.FolderChanged += ( path ) => FolderChanged?.Invoke( path );
    }

    public override bool ShowDialog()
    {
        // Track success outside the try block
        bool dialogSuccess = false;

        try
        {
            // --- NEW: ADVISE (Connect the event handler) ---
            _ = this.Dialog?.Advise( this._eventHandler, out this._eventCookie );

            // ------------------------------------------------

            // ... (existing logic to set options, title, folders, etc.)
            dialogSuccess = base.ShowDialog();
        }
        catch ( COMException )
        {
            // Handle exceptions
        }
        finally
        {
            // --- NEW: UNADVISE (Disconnect the event handler) ---
            if ( this._eventCookie != 0 )
            {
                _ = this.Dialog?.Unadvise( this._eventCookie );
                this._eventCookie = 0;
            }
        }

        return dialogSuccess;
    }
}

internal class ConsumerOfDialog
{
    /// <summary>   Consumes this object. </summary>
    /// <remarks>   2025-10-15. </remarks>
    public static void Consume()
    {
        using FilePickerDialogEventAware picker = new();
        picker.Title = "Watch the folders change";

        // Subscribe to the C# event wrapper
        picker.FolderChanged += ( path ) => Console.WriteLine( $"Dialog folder changed to: {path}" );

        if ( picker.ShowDialog() )
        {
            // ...
        }
    }

}
