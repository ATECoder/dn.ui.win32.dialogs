using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

internal static partial class IIDGuid
{
    internal const string I_FILE_SAVE_DIALOG = "84bccd23-5fde-4cdb-aea4-af64b83d78ab";
}


[ComImport(), Guid( IIDGuid.I_FILE_SAVE_DIALOG ), InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
#if NET6_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability",
    "SYSLIB1096:Convert to 'GeneratedComInterface'", Justification = "The source generator cannot handle all arguments in IFileDialog" )]
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#endif
internal interface IFileSaveDialog
{
    // Defined on IModalWindow - repeated here due to requirements of COM interop layer
    // --------------------------------------------------------------------------------

    /// <summary>   Launches a modal window. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="parent">   The handle of the owner window. This value can be NULL. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int Show( IntPtr parent ); // IModalWindow

    // Defined on IFileDialog - repeated here due to requirements of COM interop layer
    // --------------------------------------------------------------------------------

    /// <summary>   Sets the file types that the dialog can open or save. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="cFileTypes">   The number of elements in the array specified by <paramref name="rgFilterSpec"/>. </param>
    /// <param name="rgFilterSpec"> A pointer to an array of <see cref="COMDLG_FILTERSPEC"/> structures, each representing a file type. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetFileTypes( [In] uint cFileTypes, [In] COMDLG_FILTERSPEC[] rgFilterSpec );

    /// <summary>   Sets the file type that appears as selected in the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="iFileType">    The index of the file type in the file type array passed to <see cref="SetFileTypes"/>
    ///                             in its parameter. Note that this is a one-based index, not zero-
    ///                             based. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetFileTypeIndex( int iFileType );

    /// <summary>   Gets the currently selected file type. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="piFileType">   [out] A pointer to a UINT value that receives the one-based index
    ///                             of the selected file type in the file type array passed to
    ///                             <see cref="SetFileTypes"/> in its file types parameter. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetFileTypeIndex( out int piFileType );

    /// <summary>   Assigns an event handler that listens for events coming from the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pfde">         [in] A pointer to an IFileDialogEvents implementation that will
    ///                             receive events from the dialog. </param>
    /// <param name="pdwCookie">    [out] A pointer to a DWORD that receives a value identifying this
    ///                             event handler. When the client is finished with the dialog, that
    ///                             client must call the <see cref="IFileDialog.Unadvise"/> method with this value. </param>
    /// <returns>   An HRESULT. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int Advise( [In, MarshalAs( UnmanagedType.Interface )] IFileDialogEvents pfde, out uint pdwCookie );

    /// <summary>
    /// Removes an event handler that was attached through the IFileDialog::Advise method.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="dwCookie"> The DWORD value that represents the event handler. This value is
    ///                         obtained through the pdwCookie parameter of the <see cref="Advise"/>
    ///                         method. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int Unadvise( [In] uint dwCookie );

    /// <summary>   Sets flags to control the behavior of the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="fos">  The fos. One or more of the <see cref="FOS">file open dialog options</see> values. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetOptions( FOS fos );

    /// <summary>   Gets the current flags that are set to control dialog behavior. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pfos"> [out] The <see cref="FOS">file open dialog options</see>. When this method returns
    ///                     successfully, points to a value made up of one or more of the
    ///                     <see cref="FOS"/> values. </param>
    /// <returns>   The options. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetOptions( out FOS pfos );

    /// <summary>   Sets the folder used as a default if there is not a recently used folder value available. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="psi">  The <see cref="IShellItem"/>. A pointer to the interface that represents the folder. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetDefaultFolder( IShellItem psi );

    /// <summary>
    /// Sets a folder that is always selected when the dialog is opened, regardless of previous user
    /// action. Sets either the folder currently selected in the dialog, or, if the dialog is not
    /// currently displayed, the folder that is to be selected when the dialog is opened.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="psi">  The <see cref="IShellItem"/>. A pointer to the interface that represents the folder. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetFolder( IShellItem psi );

    /// <summary>   Gets a folder. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="ppsi"> [out] The <see cref="IShellItem"/>. The address of a pointer to the
    ///                     interface that represents the folder. </param>
    /// <returns>   The folder. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetFolder( out IShellItem ppsi );

    /// <summary>   Gets the user's current selection in the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="ppsi"> [out] The <see cref="IShellItem"/>. The address of a pointer to the
    ///                     interface that represents the item currently selected in the dialog. This
    ///                     item can be a file or folder selected in the view window, or something
    ///                     that the user has entered into the dialog's edit box. The latter case may
    ///                     require a parsing operation (cancelable by the user) that blocks the
    ///                     current thread. </param>
    /// <returns>   The current selection. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetCurrentSelection( out IShellItem ppsi );

    /// <summary>
    /// Sets the file name that appears in the File name edit box when that dialog box is opened.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszName">  The name. A pointer to the name of the file. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetFileName( [MarshalAs( UnmanagedType.LPWStr )] string pszName );

    /// <summary>   Retrieves the text currently entered in the dialog's File name edit box. </summary>
    /// <remarks>
    /// 2025-10-09. <para>
    /// The text in the File name edit box does not necessarily reflect the item the user chose. To
    /// get the item the user chose, use <see cref="GetResult"/>.</para>
    /// </remarks>
    /// <param name="pszName">  [out] The name. The address of a pointer to a buffer that, when this
    ///                         method returns successfully, receives the text. </param>
    /// <returns>   The file name. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetFileName( [MarshalAs( UnmanagedType.LPWStr )] out string pszName );

    /// <summary>   Sets the title of the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszTitle"> The title. A pointer to a buffer that contains the title text. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetTitle( [MarshalAs( UnmanagedType.LPWStr )] string pszTitle );

    /// <summary>   Sets the text of the Open or Save button. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszText">  The text. A pointer to a buffer that contains the button text. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetOkButtonLabel( [MarshalAs( UnmanagedType.LPWStr )] string pszText );

    /// <summary>   Sets the text of the label next to the file name edit box. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszLabel"> The label. A pointer to a buffer that contains the label text. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetFileNameLabel( [MarshalAs( UnmanagedType.LPWStr )] string pszLabel );

    /// <summary>   Gets the choice that the user made in the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="ppsi"> [out] The The <see cref="IShellItem"/>. The address of a pointer to an
    ///                     IShellItem that represents the user's choice. </param>
    /// <returns>   The result. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetResult( out IShellItem ppsi );

    /// <summary>
    /// Adds a folder to the list of places available for the user to open or save items.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="psi">          A pointer to an <see cref="IShellItem"/> that represents the
    ///                             folder to be made available to the user. This can only be a folder. </param>
    /// <param name="alignment">    Specifies where the folder is placed within the list. Specifies
    ///                             as an FDAP enum: <para>
    ///                             FDAP_BOTTOM Value: 0. The place is added to the bottom of the default
    ///                             list. </para><para>
    ///                             FDAP_TOP Value: 1. The place is added to the top of the default list.
    ///                             </para> </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int AddPlace( IShellItem psi, int alignment );

    /// <summary>   Sets the default extension to be added to file names. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszDefaultExtension">  The default extension. A pointer to a buffer that
    ///                                     contains the extension text. This string should not
    ///                                     include a leading period. For example, "jpg" is correct,
    ///                                     while ".jpg" is not. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetDefaultExtension( [MarshalAs( UnmanagedType.LPWStr )] string pszDefaultExtension );

    /// <summary>   Closes the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="hr">   The code that will be returned by <see cref="IModalWindow.Show"/> to
    ///                     indicate that the dialog was closed before a selection was made. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int Close( int hr );

    /// <summary>
    /// Enables a calling application to associate a GUID with a dialog's persisted state.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="guid"> [in,out] Unique identifier. The GUID to associate with this dialog state. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetClientGuid( [In] ref Guid guid );

    /// <summary>   Instructs the dialog to clear all persisted state information. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int ClearClientData();

    /// <summary>   Deprecated. SetFilter is no longer available for use as of Windows 7. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pFilter">  Specifies the filter. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int SetFilter( [MarshalAs( UnmanagedType.IUnknown )] object pFilter );

    /// Defined by IFileSaveDialog interface
    /// -----------------------------------------------------------------------------------.

    /// <summary>   Sets an item to be used as the initial entry in a Save As dialog. </summary>
    /// <remarks>
    /// The name of the item is displayed in the file name edit box, and the containing folder is
    /// opened in the view. This would generally be used when the application is saving an item that
    /// already exists. For new items, use <see cref="IFileDialog.SetFileName"/>.
    /// </remarks>
    /// <param name="psi">  The <see cref="IShellItem"/>. Pointer to the IShellItem that represents
    ///                     the file being saved. This is usually the item retrieved by GetResult. </param>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void SetSaveAsItem( [In, MarshalAs( UnmanagedType.Interface )] IShellItem psi );

    /// <summary>
    /// Not currently supported: IPropertyStore. Provides a property store that defines the default
    /// values to be used for the item being saved.
    /// </summary>
    /// <remarks>
    /// The IPropertyStore interface depends on the IPropertyDescription interface. The Microsoft
    /// documentation advises not to implement the IPropertyDescription interface in C# or any other
    /// language, as there is only one implementation provided by the Windows Shell itself. Instead,
    /// you would typically use a method like PSGetPropertyDescription to get an existing instance of
    /// it for a system property.
    /// </remarks>
    /// <param name="pStore">   Pointer to the IPropertyStore that represents the property store that
    ///                         contains the associated metadata. </param>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void SetProperties( [In, MarshalAs( UnmanagedType.Interface )] IntPtr pStore );

    /// <summary>
    /// Not currently supported: IPropertyDescriptionList. Specifies which properties will be
    /// collected in the save dialog.
    /// </summary>
    /// <remarks>
    /// The IPropertyDescriptionList interface depends on the IPropertyDescription interface. The Microsoft
    /// documentation advises not to implement the IPropertyDescription interface in C# or any other
    /// language, as there is only one implementation provided by the Windows Shell itself. Instead,
    /// you would typically use a method like PSGetPropertyDescription to get an existing instance of
    /// it for a system property.
    /// </remarks>
    /// <param name="pList">            Pointer to the IPropertyDescriptionList that represents
    ///                                 Pointer to the interface that represents the list of
    ///                                 properties to collect. This parameter can be NULL. </param>
    /// <param name="fAppendDefault">   TRUE to show default properties for the currently selected
    ///                                 filetype in addition to the properties specified by pList.
    ///                                 FALSE to show only properties specified by pList. </param>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void SetCollectedProperties( [In, MarshalAs( UnmanagedType.Interface )] IntPtr pList, [In] int fAppendDefault );

    /// <summary>
    /// Not currently supported: IPropertyStore. Retrieves the set of property values for a saved
    /// item or an item in the process of being saved.
    /// </summary>
    /// <remarks>
    /// The IPropertyStore interface depends on the IPropertyDescription interface. The Microsoft
    /// documentation advises not to implement the IPropertyDescription interface in C# or any other
    /// language, as there is only one implementation provided by the Windows Shell itself. Instead,
    /// you would typically use a method like PSGetPropertyDescription to get an existing instance of
    /// it for a system property.
    /// </remarks>
    /// <param name="ppStore">  [out] Address of a pointer to an IPropertyStore that receives the
    ///                         property values. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public int GetProperties( [MarshalAs( UnmanagedType.Interface )] out IntPtr ppStore );

    /// <summary>
    /// Not currently supported: IPropertyStore, IFileOperationProgressSink. Applies a set of
    /// properties to an item using the Shell's copy engine.
    /// </summary>
    /// <remarks>
    /// The IPropertyStore interface depends on the IPropertyDescription interface. The Microsoft
    /// documentation advises not to implement the IPropertyDescription interface in C# or any other
    /// language, as there is only one implementation provided by the Windows Shell itself. Instead,
    /// you would typically use a method like PSGetPropertyDescription to get an existing instance of
    /// it for a system property.
    /// </remarks>
    /// <param name="psi">      The <see cref="IShellItem"/>. Pointer to the IShellItem that
    ///                         represents the file being saved. This is usually the item retrieved
    ///                         by GetResult. </param>
    /// <param name="pStore">   Pointer to the IPropertyStore that represents the property values to
    ///                         be applied to the file. This can be the property store returned by
    ///                         <see cref="IFileSaveDialog.GetProperties"/>. </param>
    /// <param name="hwnd">     [in,out] The handle of the application window. </param>
    /// <param name="pSink">    Pointer to an optional IFileOperationProgressSink that the calling
    ///                         application can use if they want to be notified of the progress of
    ///                         the property stamping. This value may be NULL. </param>

    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    public void ApplyProperties( [In, MarshalAs( UnmanagedType.Interface )] IShellItem psi,
                   [In, MarshalAs( UnmanagedType.Interface )] IntPtr pStore,
                   [In, ComAliasName( "ShellObjects.wireHWND" )] ref IntPtr hwnd,
                   [In, MarshalAs( UnmanagedType.Interface )] IntPtr pSink );
}
