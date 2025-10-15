using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;
internal static partial class NativeMethods
{
    /// <summary>
    /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The
    /// desktop window is the area on top of which other windows are painted.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   A handle to the desktop window.. </returns>
#if NET5_0_OR_GREATER
    [LibraryImport( "user32.dll" )]
    public static partial IntPtr GetDesktopWindow();
#else
    [DllImport( "user32" )]
    public static extern IntPtr GetDesktopWindow();
#endif

}
