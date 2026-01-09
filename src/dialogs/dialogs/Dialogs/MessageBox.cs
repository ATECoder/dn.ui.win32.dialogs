using cc.isr.Win32.Native;

namespace cc.isr.Win32.Dialogs;

/// <summary>   A message box. </summary>
/// <remarks>   2025-10-09. <para>
/// <see href="https://gist.github.com/nathan130200/53dec19cdcd895281fb568ec63e1275b">MessageBox.cs</see></para> </remarks>
[CLSCompliant( false )]
public static class MessageBox
{
    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text"> The text. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, "\0", ( uint ) MessageBoxButtons.Ok );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, ( uint ) MessageBoxButtons.Ok );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, ( uint ) buttons );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="icon">     The icon. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) icon) );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="icon">     The icon. </param>
    /// <param name="button">   The button. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton button )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) icon) | (( uint ) button) );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="icon">     The icon. </param>
    /// <param name="button">   The button. </param>
    /// <param name="modal">    The modal. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton button, MessageBoxModal modal )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) icon) | (( uint ) button) | (( uint ) modal) );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="button">   The button. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton button )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) button) );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="button">   The button. </param>
    /// <param name="modal">    The modal. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton button, MessageBoxModal modal )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) button) | (( uint ) modal) );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="icon">     The icon. </param>
    /// <param name="modal">    The modal. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxModal modal )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) icon) | (( uint ) modal) );
    }

    /// <summary>   Shows. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="text">     The text. </param>
    /// <param name="caption">  The caption. </param>
    /// <param name="buttons">  The buttons. </param>
    /// <param name="modal">    The modal. </param>
    /// <returns>   A MessageBoxResult. </returns>
    public static MessageBoxResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxModal modal )
    {
        return ( MessageBoxResult ) NativeMethods.MessageBoxA( IntPtr.Zero, text, caption, (( uint ) buttons) | (( uint ) modal) );
    }
}

/// <summary>   Values that represent message box buttons. </summary>
/// <remarks>   2025-10-09. </remarks>
public enum MessageBoxButtons
{
    /// <summary>
    /// The message box contains one push button: OK. This is the default.
    /// </summary>
    Ok = 0x00000000,

    /// <summary>
    /// The message box contains two push buttons: OK and Cancel.
    /// </summary>
    OkCancel = 0x00000001,

    /// <summary>
    /// The message box contains three push buttons: Abort, Retry, and Ignore.
    /// </summary>
    AbortRetryIgnore = 0x00000002,

    /// <summary>
    /// The message box contains three push buttons: Yes, No, and Cancel.
    /// </summary>
    YesNoCancel = 0x00000003,

    /// <summary>
    /// The message box contains two push buttons: Yes and No.
    /// </summary>
    YesNo = 0x00000004,

    /// <summary>
    /// The message box contains two push buttons: Retry and Cancel.
    /// </summary>
    RetryCancel = 0x00000005,

    /// <summary>
    /// The message box contains three push buttons: Cancel, Try Again, Continue.
    /// </summary>
    CancelTryIgnore = 0x00000006,

    /// <summary>
    /// Adds a Help button to the message box.
    /// </summary>
    Help = 0x00004000,
}

/// <summary>
/// The message box returns an integer value that indicates which button the user clicked.
/// </summary>
/// <remarks>   2025-10-09. </remarks>
public enum MessageBoxResult
{
    /// <summary>
    /// The 'OK' button was selected.
    /// </summary>
    Ok = 1,

    /// <summary>
    /// The 'Cancel' button was selected.
    /// </summary>
    Cancel,

    /// <summary>
    /// The 'Abort' button was selected.
    /// </summary>
    Abort,

    /// <summary>
    /// The 'Retry' button was selected.
    /// </summary>
    Retry,

    /// <summary>
    /// The 'Ignore' button was selected.
    /// </summary>
    Ignore,

    /// <summary>
    /// The 'Yes' button was selected.
    /// </summary>
    Yes,

    /// <summary>
    /// The 'No' button was selected.
    /// </summary>
    No,

    /// <summary>
    /// The 'TryAgain' button was selected.
    /// </summary>
    TryAgain = 10,

    /// <summary>
    /// The 'Continue' button was selected.
    /// </summary>
    Continue
}

/// <summary>   To indicate the default button, specify one of the following values. </summary>
/// <remarks>   2025-10-09. </remarks>
[CLSCompliant( false )]
public enum MessageBoxDefaultButton : uint
{
    /// <summary>
    /// The first button is the default button.
    /// </summary>
    Button1 = 0x00000000,

    /// <summary>
    /// The second button is the default button.
    /// </summary>
    Button2 = 0x00000100,

    /// <summary>
    /// The third button is the default button.
    /// </summary>
    Button3 = 0x00000200,

    /// <summary>
    /// The fourth button is the default button.
    /// </summary>
    Button4 = 0x00000300,
}

/// <summary>
/// To indicate the modality of the dialog box, specify one of the following values.
/// </summary>
/// <remarks>   2025-10-09. </remarks>
[CLSCompliant( false )]
public enum MessageBoxModal : uint
{
    /// <summary>
    /// The user must respond to the message box before continuing work in the window identified by the hWnd parameter. However, the user can move to the windows of other threads and work in those windows. Depending on the hierarchy of windows in the application, the user may be able to move to other windows within the thread. All child windows of the parent of the message box are automatically disabled, but pop-up windows are not.
    /// </summary>
    Application = 0x00000000,

    /// <summary>
    /// Same as <see cref="Application"/> except that the message box has the Top Most style. Use system-modal message boxes to notify the user of serious, potentially damaging errors that require immediate attention (for example, running out of memory).
    /// </summary>
    System = 0x00001000,

    /// <summary>
    /// Same as <see cref="Application"/> except that all the top-level windows belonging to the current thread are disabled if the hWnd parameter is NULL. Use this flag when the calling application or library does not have a window handle available but still needs to prevent input to other windows in the calling thread without suspending other threads.
    /// </summary>
    Task = 0x00002000
}

/// <summary>
/// To display an icon in the message box, specify one of the following values.
/// </summary>
/// <remarks>   2025-10-09. </remarks>
[CLSCompliant( false )]
public enum MessageBoxIcon : uint
{
    /// <summary>
    /// A stop-sign icon appears in the message box.
    /// </summary>
    Error = 0x00000010,

    /// <summary>
    /// A question-mark icon appears in the message box.
    /// </summary>
    /// <remarks>
    /// The question-mark message icon is no longer recommended because it does not clearly represent a specific type of message and because the phrasing of a message as a question could apply to any message type. In addition, users can confuse the message symbol question mark with Help information. Therefore, do not use this question mark message symbol in your message boxes. The system continues to support its inclusion only for backward compatibility.
    /// </remarks>
    Question = 0x00000020,

    /// <summary>
    /// An exclamation-point icon appears in the message box.
    /// </summary>
    Warning = 0x00000030,

    /// <summary>
    /// An icon consisting of a lowercase letter `i` in a circle appears in the message box.
    /// </summary>
    Information = 0x00000040
}
