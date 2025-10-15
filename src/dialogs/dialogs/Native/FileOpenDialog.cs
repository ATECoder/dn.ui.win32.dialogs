using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   Dialog for the file open dialog. </summary>
/// <remarks>   2025-10-09. </remarks>
[ComImport, Guid( Native.NativeGuids.FILE_OPEN_DIALOG_CLS_ID )]
internal class FileOpenDialog { }

/// <summary>
/// This is the essential part: the Runtime Callable Wrapper (RCW) for the native COM class.
/// </summary>
/// <remarks>   2025-10-15. </remarks>
[ComImport]
[Guid( Native.NativeGuids.FILE_OPEN_DIALOG_CLS_ID )]
internal class FileOpenDialogRCW { }
