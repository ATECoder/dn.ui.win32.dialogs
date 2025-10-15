using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>
/// Extends the IFileDialog interface by adding methods specific to the open dialog.
/// </summary>
/// <remarks>
/// 2025-10-09.   <para>
/// Inheritance: The IOpenFileDialog interface inherits from <see cref="IFileDialog"/>. </para><para>
/// <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifiledialog"/>
/// </para><para>
/// <see href="https://www.dotnetframework.org/default.aspx/4@0/4@0/DEVDIV_TFS/Dev10/Releases/RTMRel/ndp/fx/src/WinForms/Managed/System/WinForms/FileDialog_Vista_Interop@cs/1305376/FileDialog_Vista_Interop@cs"/>
/// </para><para>
/// Notice that the interface flattens the inherited interfaces of IUnknown, IModalWindow and
/// IFileDialog. </para><para>
/// The C# compiler and runtime (when generating the RCW - Runtime Callable Wrapper) might not
/// lay out the inherited methods in the precise, sequential order required by the native COM
/// object. The native method calls end up hitting the wrong v-table entry (the wrong method
/// pointer), leading to the "server error" or an access violation. </para><para>
/// This "flat" definition guarantees the v-table layout required by the native Windows COM
/// object, resolving your "server error." You are not doing anything wrong; you are simply
/// encountering a known limitation or behavior when translating native COM inheritance to
/// managed C# inheritance for interop. </para><para>
/// </para>
/// </remarks>
[ComImport]
[Guid( Native.NativeGuids.I_FILE_OPEN_DIALOG_IID )]
[InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
#if NET6_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "Interoperability",
    "SYSLIB1096:Convert to 'GeneratedComInterface'", Justification = "The source generator cannot handle all arguments in IFileDialog" )]
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#endif
internal interface IFileOpenDialog
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
    [PreserveSig] public int SetFileTypes( [In] uint cFileTypes, [In, MarshalAs( UnmanagedType.LPArray )] COMDLG_FILTERSPEC[] rgFilterSpec );

    //     [PreserveSig] public int SetFileTypes( [In] uint cFileTypes, [In] COMDLG_FILTERSPEC[] rgFilterSpec );

    /// <summary>   Sets the file type that appears as selected in the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="iFileType">    The index of the file type in the file type array passed to <see cref="SetFileTypes"/>
    ///                             in its parameter. Note that this is a one-based index, not zero-
    ///                             based. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetFileTypeIndex( int iFileType );

    /// <summary>   Gets the currently selected file type. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="piFileType">   [out] A pointer to a UINT value that receives the one-based index
    ///                             of the selected file type in the file type array passed to
    ///                             <see cref="SetFileTypes"/> in its file types parameter. </param>
    /// <returns>   An HRESULT return code. </returns>
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
    public int Advise( [In, MarshalAs( UnmanagedType.Interface )] IFileDialogEvents pfde, out uint pdwCookie );


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
    [PreserveSig] public int SetOptions( FOS fos );

    /// <summary>   Gets the current flags that are set to control dialog behavior. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pfos"> [out] The <see cref="FOS">file open dialog options</see>. When this method returns
    ///                     successfully, points to a value made up of one or more of the
    ///                     <see cref="FOS"/> values. </param>
    /// <returns>   The options. </returns>

    [PreserveSig] public int GetOptions( out FOS pfos );

    /// <summary>   Sets the folder used as a default if there is not a recently used folder value available. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="psi">  The <see cref="IShellItem"/>. A pointer to the interface that represents the folder. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetDefaultFolder( IShellItem psi );

    /// <summary>
    /// Sets a folder that is always selected when the dialog is opened, regardless of previous user
    /// action. Sets either the folder currently selected in the dialog, or, if the dialog is not
    /// currently displayed, the folder that is to be selected when the dialog is opened.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="psi">  The <see cref="IShellItem"/>. A pointer to the interface that represents the folder. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetFolder( IShellItem psi );

    /// <summary>   Gets a folder. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="ppsi"> [out] The <see cref="IShellItem"/>. The address of a pointer to the
    ///                     interface that represents the folder. </param>
    /// <returns>   The folder. </returns>
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
    [PreserveSig] public int GetCurrentSelection( out IShellItem ppsi );

    /// <summary>
    /// Sets the file name that appears in the File name edit box when that dialog box is opened.
    /// </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszName">  The name. A pointer to the name of the file. </param>
    /// <returns>   An HRESULT return code. </returns>
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
    [PreserveSig] public int GetFileName( [MarshalAs( UnmanagedType.LPWStr )] out string pszName );

    /// <summary>   Sets the title of the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszTitle"> The title. A pointer to a buffer that contains the title text. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetTitle( [MarshalAs( UnmanagedType.LPWStr )] string pszTitle );

    /// <summary>   Sets the text of the Open or Save button. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszText">  The text. A pointer to a buffer that contains the button text. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetOkButtonLabel( [MarshalAs( UnmanagedType.LPWStr )] string pszText );

    /// <summary>   Sets the text of the label next to the file name edit box. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszLabel"> The label. A pointer to a buffer that contains the label text. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetFileNameLabel( [MarshalAs( UnmanagedType.LPWStr )] string pszLabel );

    /// <summary>   Gets the choice that the user made in the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="ppsi"> [out] The The <see cref="IShellItem"/>. The address of a pointer to an
    ///                     IShellItem that represents the user's choice. </param>
    /// <returns>   The result. </returns>
    [PreserveSig] public int GetResult( out IShellItem ppsi );

    /// <summary>   Adds a folder to the list of places available for the user to open or save items.. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="psi">          A pointer to an <see cref="IShellItem"/> that represents the folder to be made available to the user. This can only be a folder. </param>
    /// <param name="alignment">    Specifies where the folder is placed within the list. Specifies as an FDAP enum: <para>
    /// FDAP_BOTTOM Value: 0. The place is added to the bottom of the default list. </para><para>
    /// FDAP_TOP Value: 1. The place is added to the top of the default list. </para> </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int AddPlace( IShellItem psi, int alignment );

    /// <summary>   Sets the default extension to be added to file names. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pszDefaultExtension">  The default extension. A pointer to a buffer that
    ///                                     contains the extension text. This string should not
    ///                                     include a leading period. For example, "jpg" is correct,
    ///                                     while ".jpg" is not. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetDefaultExtension( [MarshalAs( UnmanagedType.LPWStr )] string pszDefaultExtension );

    /// <summary>   Closes the dialog. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="hr">   The code that will be returned by <see cref="IFileOpenDialog.Show"/> to
    ///                     indicate that the dialog was closed before a selection was made. </param>
    /// <returns>   An HRESULT return code. </returns>
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
    [PreserveSig] public int ClearClientData();

    /// <summary>   Deprecated. SetFilter is no longer available for use as of Windows 7. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="pFilter">  Specifies the filter. </param>
    /// <returns>   An HRESULT return code. </returns>
    [PreserveSig] public int SetFilter( [MarshalAs( UnmanagedType.IUnknown )] object pFilter );

    // Defined by IFileOpenDialog interface
    // -----------------------------------------------------------------------------------

    /// <summary>   Gets the user's choices in a dialog that allows multiple selection. </summary>
    /// <remarks>
    /// 2025-10-09. <para>
    /// This method can be used whether the selection consists of a single item or multiple items.
    /// <see cref="IFileOpenDialog.GetResults"/> can be called after the dialog has closed or during
    /// the handling of an <see cref="IFileDialogEvents.OnFileOk"/> event. Calling this method at any
    /// other time will fail.
    /// <see cref="IModalWindow.Show"/> must return a success code for a result to be available to <see cref="IFileOpenDialog.GetResults"/>.
    /// </para>
    /// </remarks>
    /// <param name="ppenum">   [out] The <see cref="IShellItemArray">results</see>. The address of a
    ///                         pointer to an IShellItemArray through which the items selected in the
    ///                         dialog can be accessed. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetResults( out IShellItemArray ppenum );

    /// <summary>
    /// Gets the currently selected items in the dialog. These items may be items selected in the
    /// view, or text selected in the file name edit box.
    /// </summary>
    /// <remarks>
    /// 2025-10-09. <para>
    /// This method can be used for single item or multiple item selections. If the user has entered
    /// new text in the file name field, this can be a time-consuming operation. When the application
    /// calls this method, the application parses the text in the filename field. For example, if
    /// this is a network share, the operation could take some time. However, this operation will not
    /// block the UI, since the user should able to stop the operation, which will result in
    /// <see cref="IFileOpenDialog.GetSelectedItems"/> returning a failure code).</para>
    /// </remarks>
    /// <param name="ppsai">    [out] The selected items. The address of a pointer to an
    ///                         IShellItemArray through which the selected items can be accessed. </param>
    /// <returns>   An HRESULT return code. </returns>
    [MethodImpl( MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime )]
    [PreserveSig] public int GetSelectedItems( [MarshalAs( UnmanagedType.IUnknown )] out object ppsai );
}
