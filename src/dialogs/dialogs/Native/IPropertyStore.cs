using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   This interface exposes methods used to enumerate and manipulate property values. </summary>
/// <remarks>
/// The Microsoft documentation advises not to implement the IPropertyDescription in C# or any other
/// language, as there is only one implementation provided by the Windows Shell itself. Instead,
/// you would typically use a method like PSGetPropertyDescription to get an existing instance of
/// it for a system property.
/// </remarks>
[ComImport, Guid( "886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99" ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
internal interface IPropertyStore
{
    /// <summary>
    /// This method returns a count of the number of properties that are attached to the file.
    /// </summary>
    /// <param name="cProps">   [out] A pointer to a value that indicates the property count.. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public int GetCount( [Out] out uint cProps );

    /// <summary>   Gets a property key from the property array of an item. </summary>
    /// <param name="iProp">    The index of the property key in the array of PROPERTYKEY structures.
    ///                         This is a zero-based index. </param>
    /// <param name="pkey">     [out] The pkey. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public int GetAt( [In] uint iProp, out PROPERTYKEY pkey );

    /// <summary>   his method retrieves the data for a specific property. </summary>
    /// <param name="key">  [in,out] The key. </param>
    /// <param name="pv">   [out] After the <see cref="IPropertyStore.GetValue"/> method returns successfully,
    ///                     this parameter points to a PROPVARIANT structure that contains data about
    ///                     the property. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public int GetValue( [In] ref PROPERTYKEY key, out object pv );

    /// <summary>   This method sets a property value or replaces or removes an existing value.. </summary>
    /// <param name="key">  [in,out] The key. </param>
    /// <param name="pv">   [out] After the <see cref="IPropertyStore.GetValue"/> method returns
    ///                     successfully, this parameter points to a PROPVARIANT structure that
    ///                     contains data about the property. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public int SetValue( [In] ref PROPERTYKEY key, [In] ref object pv );

    /// <summary>   After a change has been made, this method saves the changes. </summary>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public int Commit();
}

/// <summary>   A property key. </summary>
/// <remarks>   2025-10-14. </remarks>
[StructLayout( LayoutKind.Sequential, Pack = 4 )]
internal struct PROPERTYKEY
{
    public Guid fmtid;
    public uint pid;
}
