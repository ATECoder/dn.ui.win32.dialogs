using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>
/// Exposes methods that retrieve information about a Shell item. IShellItem and IShellItem2 are
/// the preferred representations of items in any new code.
/// </summary>
/// <remarks>   2025-10-09. <para>
/// <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</see></para></remarks>
#if NET5_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability", "SYSLIB1096:Convert to 'GeneratedComInterface'", Justification = "<Pending>" )]
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#endif
[ComImport, Guid( Native.NativeGuids.I_SHELL_ITEM_IID ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
internal interface IShellItem
{
    /// <summary>   Handler, called when the bind to. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   An int. </returns>
    [PreserveSig] public int BindToHandler(); // not fully defined

    /// <summary>   Gets the parent of this item. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   The parent. </returns>
    [PreserveSig] public int GetParent(); // not fully defined

    /// <summary>   Gets display name. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="sigdnName">    Name of the SIGDN. </param>
    /// <param name="ppszName">     [out] Name.. </param>
    /// <returns>   The display name. </returns>
    [PreserveSig] public int GetDisplayName( SIGDN sigdnName, [MarshalAs( UnmanagedType.LPWStr )] out string ppszName );

    /// <summary>   Gets the attributes. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   The attributes. </returns>
    [PreserveSig] public int GetAttributes();  // not fully defined

    /// <summary>   Compares objects. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>
    /// Negative if '' is less than '', 0 if they are equal, or positive if it is greater.
    /// </returns>
    [PreserveSig] public int Compare();  // not fully defined
}

