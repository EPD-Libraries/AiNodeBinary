using AinbLibrary.IO.Structures;
using Revrs;
using Revrs.Extensions;
using System.Runtime.CompilerServices;

namespace AinbLibrary.IO;

public unsafe ref struct AinbNodeContentReader(Span<byte> buffer)
{
    private readonly Span<byte> _buffer = buffer;
    private readonly Span<int> _offsets = buffer[sizeof(AinbNodeContentHeader)..].ReadSpan<int>();

    public AinbNodeContentHeader Header = buffer.Read<AinbNodeContentHeader>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ref T ReadConnection<T>(int index) where T : unmanaged
    {
        int offset = _offsets[index];
        return ref _buffer[offset..].Read<T>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly RevrsReader OpenReadConnection(int index)
    {
        int offset = _offsets[index];
        return new RevrsReader(_buffer[offset..]);
    }
}
