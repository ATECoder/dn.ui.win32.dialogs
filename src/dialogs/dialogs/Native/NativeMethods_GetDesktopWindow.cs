// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/f21a2666c577306e437f80fe934d76cdb15072a5/src/libraries/Common/src/Interop/Windows/Shell32/Interop.SHGetKnownFolderPath.cs

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
