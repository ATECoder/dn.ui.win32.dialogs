using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   Interface for file dialog events. </summary>
/// <remarks>   2025-10-14. <para>
/// <see href="https://www.pinvoke.net/default.aspx/Interfaces.IFileDialogEvents"/></para> </remarks>
[ComImport, Guid( "973510DB-7D7F-452B-8975-74A85828D354" ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
internal interface IFileDialogEvents
{
    // NOTE: some of these callbacks are cancelable - returning S_FALSE means that
    // the dialog should not proceed (e.g. with closing, changing folder); to
    // support this, we need to use the PreserveSig attribute to enable us to return
    // the proper HRESULT
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime ), PreserveSig]
    public int OnFileOk( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd );

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime ), PreserveSig]
    public int OnFolderChanging( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd,
                   [In, MarshalAs( UnmanagedType.Interface )] IShellItem psiFolder );

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void OnFolderChange( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd );

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void OnSelectionChange( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd );

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void OnShareViolation( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd,
                [In, MarshalAs( UnmanagedType.Interface )] IShellItem psi,
                out FDE_SHAREVIOLATION_RESPONSE pResponse );

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void OnTypeChange( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd );

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void OnOverwrite( [In, MarshalAs( UnmanagedType.Interface )] IFileDialog pfd,
               [In, MarshalAs( UnmanagedType.Interface )] IShellItem psi,
               out FDE_OVERWRITE_RESPONSE pResponse );
}

internal enum FDE_SHAREVIOLATION_RESPONSE
{
    FDESVR_DEFAULT = 0x00000000,
    FDESVR_ACCEPT = 0x00000001,
    FDESVR_REFUSE = 0x00000002
}

internal enum FDE_OVERWRITE_RESPONSE
{
    FDEOR_DEFAULT = 0x00000000,
    FDEOR_ACCEPT = 0x00000001,
    FDEOR_REFUSE = 0x00000002
}
