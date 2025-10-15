using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

internal static class CLSIDGuid
{
    internal const string FILE_OPEN_DIALOG = "DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7";
}

/// <summary>   Dialog for setting the file open. </summary>
/// <remarks>   2025-10-09. </remarks>
[ComImport, Guid( "DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7" )] // CLSID_FileOpenDialog
internal class FileOpenDialog { }

