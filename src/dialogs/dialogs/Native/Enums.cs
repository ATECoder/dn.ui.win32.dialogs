namespace cc.isr.Win32.Native;

/// <summary>
/// Request the form of an item's display name to retrieve through <see cref="IShellItem.GetDisplayName(SIGDN, out string)"/>
/// and IVirtualDesktopManager.SHGetNameFromIDList.
/// </summary>
/// <remarks>
/// 2025-10-09. <para>
/// <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-sigdn"/>
/// </para>
/// </remarks>
#if NET5_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.SuppressMessage( "CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "<Pending>" )]
#pragma warning disable CA1712 // Do not prefix enum values with type name
#endif
internal enum SIGDN : uint
{
    /// <summary>   Returns the display name relative to the parent folder.
    /// In UI this name is generally ideal for display to the user. </summary>
    SIGDN_NORMALDISPLAY = 0,

    /// <summary>   Returns the editing name relative to the desktop. In UI this name is suitable for display to the user. </summary>
    SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,

    /// <summary>   Returns the parsing name relative to the desktop. This name is not suitable for use in UI. </summary>
    SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,

    /// <summary>    Returns the item's file system path, if it has one. Only items that report SFGAO_FILESYSTEM have
    /// a file system path. When an item does not have a file system path, a call to IShellItem::GetDisplayName on that
    /// item will fail. In UI this name is suitable for display to the user in some cases, but note that it might not be specified for all items. </summary>
    SIGDN_FILESYSPATH = 0x80058000,

    /// <summary>    Returns the parsing name relative to the parent folder. This name is not suitable for use in UI. </summary>
    SIGDN_PARENTRELATIVE = 0x80080001,

    /// <summary>   Returns the editing name relative to the parent folder. In UI this name is suitable for display to the user. </summary>
    SIGDN_PARENTRELATIVEEDITING = 0x80031001,

    /// <summary>
    /// Returns the path relative to the parent folder in a friendly format as displayed in an address bar. This name is suitable for display to the user.
    /// </summary>
    SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,

    /// <summary>    Returns the path relative to the parent folder. </summary>
    SIGDN_PARENTRELATIVEPARSING = 0x80018001,

    /// <summary>   Returns the item's URL, if it has one. Some items do not have a URL, and in those cases a call to
    /// IShellItem::GetDisplayName will fail. This name is suitable for display to the user in some cases, but note
    /// that it might not be specified for all items. </summary>
    SIGDN_URL = 0x80068000,

    /// <summary>    Introduced in Windows 8.. </summary>
    SIGDN_PARENTRELATIVEFORUI = 0x80094001,
}

/// <summary>
/// A bit-field of flags for specifying the set of options available to an Open or Save dialog.
/// </summary>
/// <remarks>   2025-10-09. <para>
/// <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-_FileOpenDialogOptions">File Open Dialog Options</see></para></remarks>
[Flags]
internal enum FOS
{
    /// <summary>   When saving a file, prompt before overwriting an existing file of the same name.
    /// This is a default value for the Save dialog. </summary>
    FOS_OVERWRITEPROMPT = 0x2,

    /// <summary>   In the Save dialog, only allow the user to choose a file that has one of the file
    /// name extensions specified through IFileDialog::SetFileTypes.. </summary>
    FOS_STRICTFILETYPES = 0x4,

    /// <summary>   Don't change the current working directory.. </summary>
    FOS_NOCHANGEDIR = 0x8,

    /// <summary>   Present an Open dialog that offers a choice of folders rather than files.. </summary>
    FOS_PICKFOLDERS = 0x20,

    /// <summary>   Ensures that returned items are file system items (SFGAO_FILESYSTEM). Note that this does not
    /// apply to items returned by IFileDialog::GetCurrentSelection.. </summary>
    FOS_FORCEFILESYSTEM = 0x40,

    /// <summary>   Enables the user to choose any item in the Shell namespace, not just those with SFGAO_STREAM
    /// or SFAGO_FILESYSTEM attributes. This flag cannot be combined with FOS_FORCEFILESYSTEM.. </summary>
    FOS_ALLNONSTORAGEITEMS = 0x80,

    /// <summary>   Do not check for situations that would prevent an application from opening the selected file,
    /// such as sharing violations or access denied errors. </summary>
    FOS_NOVALIDATE = 0x100,

    /// <summary>   Enables the user to select multiple items in the open dialog. Note that when this flag is set,
    /// the IFileOpenDialog interface must be used to retrieve those items. </summary>
    FOS_ALLOWMULTISELECT = 0x200,

    /// <summary>   The item returned must be in an existing folder. This is a default value. </summary>
    FOS_PATHMUSTEXIST = 0x800,

    /// <summary>   The item returned must exist. This is a default value for the Open dialog. </summary>
    FOS_FILEMUSTEXIST = 0x1000,

    /// <summary>   Prompt for creation if the item returned in the open dialog does not exist. Note that this does not
    /// actually create the item. </summary>
    FOS_CREATEPROMPT = 0x2000,

    /// <summary>   In the case of a sharing violation when an application is opening a file, call the application back
    /// through OnShareViolation for guidance. This flag is overridden by FOS_NOVALIDATE. </summary>
    FOS_SHAREAWARE = 0x4000,

    /// <summary>   Do not return read-only items. This is a default value for the Save dialog. </summary>
    FOS_NOREADONLYRETURN = 0x8000,

    /// <summary>   Do not test whether creation of the item as specified in the Save dialog will be successful.
    /// If this flag is not set, the calling application must handle errors, such as denial of access, discovered when the item is created. </summary>
    FOS_NOTESTFILECREATE = 0x10000,

    /// <summary>   Hide the list of places from which the user has recently opened or saved items. This value is not supported as of Windows 7. </summary>
    FOS_HIDEMRUPLACES = 0x20000,

    /// <summary>   Hide items shown by default in the view's navigation pane. This flag is often used in conjunction with the
    /// IFileDialog::AddPlace method, to hide standard locations and replace them with custom locations. 
    /// Windows 7 and later. Hide all of the standard namespace locations (such as Favorites, Libraries, Computer, and Network)
    /// shown in the navigation pane.</summary>
    FOS_HIDEPINNEDPLACES = 0x40000,

    /// <summary>   Shortcuts should not be treated as their target items. This allows an application to open a .lnk file
    /// rather than what that file is a shortcut to. </summary>
    FOS_NODEREFERENCELINKS = 0x100000,

    /// <summary>   The OK button will be disabled until the user navigates the view or edits the filename (if applicable).
    /// Note: Disabling of the OK button does not prevent the dialog from being submitted by the Enter key. </summary>
    FOS_OKBUTTONNEEDSINTERACTION = 0x200000,

    /// <summary>   Do not add the item being opened or saved to the recent documents list (SHAddToRecentDocs). </summary>
    FOS_DONTADDTORECENT = 0x2000000,

    /// <summary>   Include hidden and system items. </summary>
    FOS_FORCESHOWHIDDEN = 0x10000000,

    /// <summary>   Indicates to the Save As dialog box that it should open in expanded mode. Expanded mode is the mode that is set and unset
    /// by clicking the button in the lower-left corner of the Save As dialog box that switches between Browse Folders and Hide Folders when clicked. This value is not supported as of Windows 7. </summary>
    FOS_DEFAULTNOMINIMODE = 0x20000000,

    /// <summary>   Indicates to the Open dialog box that the preview pane should always be displayed. </summary>
    FOS_FORCEPREVIEWPANEON = 0x40000000,

    /// <summary>   Indicates that the caller is opening a file as a stream (BHID_Stream), so there is no need to download that file. </summary>
    FOS_SUPPORTSTREAMABLEITEMS = unchecked(( int ) 0x80000000)
}

/// <summary>   Specifies list placement. </summary>
/// <remarks>   2025-10-15. </remarks>
internal enum FDAP
{
    FDAP_BOTTOM = 0x00000000, // For AddPlace
    FDAP_TOP = 0x00000001,    // For AddPlace
}

/// <summary>   Values that represent fde share violation responses. </summary>
/// <remarks>   2025-10-15. </remarks>
internal enum FDE_SHAREVIOLATION_RESPONSE
{
    FDESVR_DEFAULT = 0x00000000,
    FDESVR_ACCEPT = 0x00000001,
    FDESVR_REFUSE = 0x00000002
}

/// <summary>   Values that represent fde overwrite responses. </summary>
/// <remarks>   2025-10-15. </remarks>
internal enum FDE_OVERWRITE_RESPONSE
{
    FDEOR_DEFAULT = 0x00000000,
    FDEOR_ACCEPT = 0x00000001,
    FDEOR_REFUSE = 0x00000002
}

/// <summary>   Values that represent Dialog events. </summary>
/// <remarks>   2025-10-15. </remarks>
internal enum DLG_EVENTS : uint
{
    FDE_OVERWRITE = 0x00000000,
    FDE_FILEOK = 0x00000001,
    FDE_FOLDERCHANGE = 0x00000002, // <--- Fired when the user navigates to a new folder
    FDE_SELECTIONCHANGE = 0x00000003,
    FDE_SHAREVIOLATION = 0x00000004,
    FDE_TYPECHANGE = 0x00000005,
    FDE_DIALOGINIT = 0x00000006,
    FDE_CONTAINERCHANGE = 0x00000007,
    FDE_PARTIALOPEN = 0x00000008,
    FDE_LOCKVIEWCHANGE = 0x00000009
}
