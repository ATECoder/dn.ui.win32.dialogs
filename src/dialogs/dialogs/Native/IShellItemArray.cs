using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   Interface for shell item array. </summary>
/// <remarks>   2025-10-09. </remarks>
#if NET5_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability", "SYSLIB1096:Convert to 'GeneratedComInterface'", Justification = "<Pending>" )]
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#endif
[ComImport, Guid( "b63ea76d-1f85-456f-a19c-48159efa858b" ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
internal interface IShellItemArray
{
    /// <summary>   Handler, called when the bind to. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   An int. </returns>
    [PreserveSig] public int BindToHandler();  // not fully defined

    /// <summary>   Gets property store. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   The property store. </returns>
    [PreserveSig] public int GetPropertyStore();  // not fully defined

    /// <summary>   Gets property description list. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   The property description list. </returns>
    [PreserveSig] public int GetPropertyDescriptionList();  // not fully defined

    /// <summary>   Gets the attributes. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   The attributes. </returns>
    [PreserveSig] public int GetAttributes();  // not fully defined

    /// <summary>   Gets a count. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pdwNumItems">  [out] The pdw number items. </param>
    /// <returns>   The count. </returns>
    [PreserveSig] public int GetCount( out int pdwNumItems );

    /// <summary>   Gets item at. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="dwIndex">  Zero-based index of the. </param>
    /// <param name="ppsi">     [out] The ppsi. </param>
    /// <returns>   The item at. </returns>
    [PreserveSig] public int GetItemAt( int dwIndex, out IShellItem ppsi );

    /// <summary>   Enum items. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   An int. </returns>
    [PreserveSig] public int EnumItems();  // not fully defined
}
