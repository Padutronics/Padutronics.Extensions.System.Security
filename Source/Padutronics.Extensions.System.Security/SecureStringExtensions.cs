using System.Runtime.InteropServices;
using System.Security;

namespace Padutronics.Extensions.System.Security;

public static class SecureStringExtensions
{
    public static string ToUnsecureString(this SecureString @this)
    {
        nint pointer = nint.Zero;

        try
        {
            pointer = Marshal.SecureStringToGlobalAllocUnicode(@this);

            return Marshal.PtrToStringUni(pointer) ?? string.Empty;
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(pointer);
        }
    }
}