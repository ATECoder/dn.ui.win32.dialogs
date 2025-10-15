using System.Runtime.InteropServices;

namespace cc.isr.Win32.Native;

/// <summary>   A native methods. </summary>
/// <remarks>   2023-04-26. </remarks>
internal static partial class NativeMethods
{
    /// <summary>   (Immutable) the cancelled value of HRESULT. </summary>
    public const int ERROR_CANCELLED = unchecked(( int ) 0x800704C7);

    /// <summary>   Check the HRESULT return code. </summary>
    /// <remarks>
    /// 2025-10-09. <para>
    /// An HRESULT is a 32-bit value used in Windows programming to indicate the success or failure
    /// of an operation and provide status information. It contains a severity code (0 for success, 1
    /// for failure) and other bits for a facility code (the area of the system involved) and an
    /// error code (the specific condition). HRESULTs are common in COM (Component Object Model) and
    /// are defined in Windows system header files. </para><para>
    /// Original Intent: According to a Microsoft historian, in the early days of development,
    /// HRESULT was intended to be a handle to a richer object that contained detailed error
    /// information and a history of the error. </para><para>
    /// Current Reality: The team later decided that this complexity wasn't worth the cost, and the
    /// HRESULT was changed to be a simple 32-bit numerical value that encodes all the error
    /// information (severity, facility, and code) directly into the number itself, rather than
    /// pointing to another object. </para><para>
    ///  The Name Stuck: The name "HRESULT" (Result Handle) remained, even though the value is not
    /// actually a handle in modern Windows programming. </para><pata>
    /// In short, while it technically means "Handle," it functions today as a simple 32-bit return
    /// code for success or failure, especially in COM programming.</pata>
    /// </remarks>
    /// <param name="returnCode">   The <see href="https://learn.microsoft.com/en-us/office/client-developer/outlook/mapi/hresult">
    ///                             HRESULT</see>. </param>
    /// <param name="throwOnError"> True to throw on error. </param>
    /// <param name="ex">           [out] The exception if not thrown. </param>
    /// <returns>
    /// <see href="https://learn.microsoft.com/en-us/office/client-developer/outlook/mapi/hresult">
    /// HRESULT</see>.
    /// </returns>
    public static int CheckReturnCode( int returnCode, bool throwOnError, out Exception? ex )
    {
        ex = null;
        if ( returnCode == 0 )
        {
        }
        else if ( throwOnError )
        {
            Marshal.ThrowExceptionForHR( returnCode );
        }
        else
        {
            try
            {
                Marshal.ThrowExceptionForHR( returnCode );
            }
            catch ( Exception exp )
            {
                ex = exp;
            }
        }
        return returnCode;
    }

    /// <summary>   Check the HRESULT return code. </summary>
    /// <remarks>   2025-10-09. </remarks>
    /// <param name="returnCode">   The <see href="https://learn.microsoft.com/en-us/office/client-developer/outlook/mapi/hresult">
    ///                             HRESULT</see>. </param>
    /// <param name="throwOnError"> True to throw on error. </param>
    /// <param name="details">      [out] provides information in case the HRESULT signifies a
    ///                             failure. </param>
    /// <returns>
    /// <see href="https://learn.microsoft.com/en-us/office/client-developer/outlook/mapi/hresult">
    /// HRESULT</see>.
    /// </returns>
    public static int CheckReturnCode( int returnCode, bool throwOnError, out string details )
    {
        details = 0 == NativeMethods.CheckReturnCode( returnCode, throwOnError, out Exception? ex )
            ? string.Empty
            : ex is null
                ? $"HRESULT: 0x{returnCode:X8}"
                : ex.Message;
        return returnCode;
    }
}

