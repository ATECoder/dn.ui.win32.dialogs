using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   Used generically to filter elements. </summary>
/// <remarks>   2025-10-14. </remarks>
[StructLayout( LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4 )]
internal struct COMDLG_FILTERSPEC
{
    /// <summary>   A pointer to a buffer that contains the friendly name of the filter. </summary>
    [MarshalAs( UnmanagedType.LPWStr )]
    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Style", "IDE1006:Naming Styles", Justification = "<Pending>" )]
    public string pszName;

    /// <summary>   A pointer to a buffer that contains the filter pattern. </summary>
    [MarshalAs( UnmanagedType.LPWStr )]
    [System.Diagnostics.CodeAnalysis.SuppressMessage( "Style", "IDE1006:Naming Styles", Justification = "<Pending>" )]
    public string pszSpec;
}

#if false
COMDLG_FILTERSPEC rgSpec[] =
{ 
    { "JPG", "*.jpg;*.jpeg" },
    { "BMP", "*.bmp" },
    { "All", "*.*" },
};
#endif

