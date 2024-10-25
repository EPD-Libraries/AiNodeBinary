using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace AinbLibrary.Legacy.Extensions;

public static unsafe class Utf8Extension
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe string GetString(this Span<byte> utf8)
        => GetString((ReadOnlySpan<byte>)utf8);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetString(this ReadOnlySpan<byte> utf8)
    {
        fixed (byte* ptr = utf8) {
            return Utf8StringMarshaller.ConvertToManaged(ptr)
                ?? string.Empty;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetString<T>(this T value) where T : unmanaged
    {
        ulong uint64 = Convert.ToUInt64(value);
        fixed (byte* ptr = BitConverter.GetBytes(uint64)) {
            return Utf8StringMarshaller.ConvertToManaged(ptr) ?? string.Empty;
        }
    }
}
