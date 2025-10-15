using System.Runtime.InteropServices;
#if NET5_0_OR_GREATER
using System.Runtime.InteropServices.ComTypes;
#else
using System.Runtime.InteropServices.ComTypes;
#endif

namespace cc.isr.Win32.Native;
internal static partial class NativeMethods
{
    /// <summary>   Creates and initializes a Shell item object from a parsing name. </summary>
    /// <remarks>   2025-10-09. <para>
    /// Code generation is not supported for the <see cref="Guid"/> and <see cref="IShellItem"/></para></remarks>
    /// <param name="pszPath">  A pointer to a full pathname of the file. </param>
    /// <param name="pbc">      Optional. A pointer to a <see href="https://learn.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ibindctx">
    ///                         bind context</see> used to pass parameters as inputs and outputs to
    ///                         the parsing function. These passed parameters are often specific to
    ///                         the data source and are documented by the data source owners. 
    ///                         (not typically needed, pass IntPtr.Zero). </param>
    /// <param name="riid">     A reference to a GUID. The IID of the interface to retrieve through ppv,
    ///                         typically IID_IShellItem or IID_IShellItem2. </param>
    /// <param name="ppv">      [out] COM interface pointer. When this method returns successfully, contains the interface
    ///                         pointer requested in <paramref name="riid"/>. This is typically <see href="https://learn.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">
    ///                         IShellItem</see> or <see href="https://learn.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem2">
    ///                         IShellItem2</see>. </param>
    /// <returns>   An int. </returns>
#if NET5_0_OR_GREATER
    [DllImport( "shell32" )]
    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability",
        "SYSLIB1054:Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time",
        Justification = "Code generation is not supported for Guid and IShellItem" )]
    public static extern int SHCreateItemFromParsingName( [MarshalAs( UnmanagedType.LPWStr )] string pszPath, IBindCtx? pbc,
        [MarshalAs( UnmanagedType.LPStruct )] Guid riid, out IShellItem ppv );
#else
    [DllImport( "shell32" )]
    public static extern int SHCreateItemFromParsingName( [MarshalAs( UnmanagedType.LPWStr )] string pszPath, IBindCtx? pbc,
        [MarshalAs( UnmanagedType.LPStruct )] Guid riid, out IShellItem ppv );
#endif
}
