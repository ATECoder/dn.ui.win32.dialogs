// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/f21a2666c577306e437f80fe934d76cdb15072a5/src/libraries/Common/src/Interop/Windows/Shell32/Interop.SHGetKnownFolderPath.cs

using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   Exposes a method that represents a modal window.. </summary>
/// <remarks>   2025-10-14. <para> 
/// Inheritance: The IModalWindow interface inherits from the <see cref="IUnknown "/> interface.
/// </para><para>
/// <see href="https://www.pinvoke.net/"/></para></remarks>
[ComImport]
[Guid( Native.NativeGuids.I_MODAL_WINDOW_IID )]
[InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
#if NET6_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability",
    "SYSLIB1096:Convert to 'GeneratedComInterface'", Justification = "The source generator cannot handle all arguments in IFileDialog" )]
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#endif
internal interface IModalWindow
{
    /// <summary>   Launches a modal window. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="parent">   The handle of the owner window. This value can be NULL. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int Show( IntPtr parent ); // IModalWindow
}
