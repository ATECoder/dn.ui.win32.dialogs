using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>
/// Enables clients to get pointers to other interfaces on a given object through the
/// QueryInterface method, and manage the existence of the object through the AddRef and Release
/// methods. All other COM interfaces are inherited, directly or indirectly, from IUnknown.
/// Therefore, the three methods in <see cref="IUnknown"/> are the first entries in the vtable for every
/// interface.
/// </summary>
/// <remarks>   2025-10-14. </remarks>
[ComVisible( false )]
[ComImport, InterfaceType( ComInterfaceType.InterfaceIsIUnknown ), Guid( "00000000-0000-0000-C000-000000000046" )]
#if NET6_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability",
    "SYSLIB1096:Convert to 'GeneratedComInterface'", Justification = "The source generator cannot handle all arguments in IFileDialog" )]
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#endif
internal interface IUnknown
{
    /// <summary>
    /// A helper function template that infers an interface identifier, and calls <see cref="QueryInterface"/>
    /// (REFIID,void).
    /// </summary>
    /// <param name="riid"> [in,out] The riid. The address of a pointer to an interface. For details,
    ///                     see the ppvObject parameter of QueryInterface(REFIID,void). </param>
    /// <returns>   The interface. </returns>
    public IntPtr QueryInterface( ref Guid riid );

    /// <summary>
    /// Increments the reference count for an interface pointer to a COM object. You should call this
    /// method whenever you make a copy of an interface pointer.
    /// </summary>
    /// <remarks>
    /// A COM object uses a per-interface reference-counting mechanism to ensure that the object
    /// doesn't outlive references to it. You use AddRef to stabilize a copy of an interface pointer.
    /// It can also be called when the life of a cloned pointer must extend beyond the lifetime of
    /// the original pointer. The cloned pointer must be released by calling <see cref="IUnknown.Release"/>
    /// on it.
    /// 
    /// The internal reference counter that AddRef maintains should be a 32-bit unsigned integer. <para>
    /// 
    /// Call this method for every new copy of an interface pointer that you make. For example, if
    /// you return a copy of a pointer from a method, then you must call AddRef on that pointer. You
    /// must also call AddRef on a pointer before passing it as an in-out parameter to a method; the
    /// method will call IUnknown::Release before copying the out-value on top of it.</para>
    /// </remarks>
    /// <returns>
    /// The method returns the new reference count. This value is intended to be used only for test
    /// purposes.
    /// </returns>
    [PreserveSig]
    public uint AddRef();

    /// <summary>   Decrements the reference count for an interface on a COM object. </summary>
    /// <remarks>
    /// When the reference count on an object reaches zero, Release must cause the interface pointer
    /// to free itself. When the released pointer is the only (formerly) outstanding reference to an
    /// object (whether the object supports single or multiple interfaces), the implementation must
    /// free the object.
    /// 
    /// Note that aggregation of objects restricts the ability to recover interface pointers.
    /// 
    /// Notes to callers: <para>
    /// Call this method when you no longer need to use an interface pointer. If you are writing a
    /// method that takes an in-out parameter, call Release on the pointer you are passing in before
    /// copying the out-value on top of it.
    /// </para> </remarks>
    /// <returns>
    /// An uint. The method returns the new reference count. This value is intended to be used only
    /// for test purposes.
    /// </returns>
    [PreserveSig]
    public uint Release();
}
