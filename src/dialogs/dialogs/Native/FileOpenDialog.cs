// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/runtime/blob/f21a2666c577306e437f80fe934d76cdb15072a5/src/libraries/Common/src/Interop/Windows/Shell32/Interop.SHGetKnownFolderPath.cs

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
