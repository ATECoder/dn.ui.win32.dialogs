using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   A native methods. </summary>
/// <remarks>   2023-04-26. </remarks>
internal static partial class NativeMethods
{
    /// <summary>   Message box a. </summary>
    /// <remarks>   2025-10-10. </remarks>
    /// <param name="hWnd">         The window; IntPtr in C#. </param>
    /// <param name="lpText">       The text; string in C#, marshalled as ANSI/UTF8. </param>
    /// <param name="lpCaption">    The caption; string in C#, marshalled as ANSI/UTF8. </param>
    /// <param name="uType">        The type; uint in C#. </param>
    /// <returns>   An int. </returns>
#if NET5_0_OR_GREATER
    [LibraryImport( "user32.dll",
        // The EntryPoint must be the exact native function name, 'MessageBoxA'.
        EntryPoint = "MessageBoxA",
        // StringMarshalling.Utf8 is used to tell the source generator to marshal 
        // the C# strings to ANSI (single-byte) strings, matching the 'A' function.
        StringMarshalling = StringMarshalling.Utf8 )]
    public static partial int MessageBoxA(
        IntPtr hWnd,
        string lpText,
        string lpCaption,
        uint uType );
#else
    [DllImport( "user32.dll", CharSet = CharSet.Unicode )]
    public static extern int MessageBoxA( IntPtr hWnd, string lpText, string lpCaption, uint uType );
#endif
}

internal class Example
{
    public static void Main()
    {
        // Call the imported method.
        // Parameters: (Owner Window Handle, Message, Title, Type)
        _ = NativeMethods.MessageBoxA(
            IntPtr.Zero, // No owner window
            "Hello from LibraryImport with MessageBoxA!",
            "ANSI P/Invoke",
            0x00000040 ); // MB_ICONINFORMATION
    }
}
