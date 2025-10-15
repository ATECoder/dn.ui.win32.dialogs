using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

internal static partial class IIDGuid
{
    internal const string I_MODAL_WINDOW = "b4db1657-70d7-485e-8e3e-6fcb5a5c1802";
}

/// <summary>   Exposes a method that represents a modal window.. </summary>
/// <remarks>   2025-10-14. <para> 
/// Inheritance: The IModalWindow interface inherits from the <see cref="IUnknown "/> interface.
/// </para><para>
/// <see href="https://www.pinvoke.net/"/></para></remarks>
[ComImport]
[Guid( IIDGuid.I_MODAL_WINDOW )]
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
