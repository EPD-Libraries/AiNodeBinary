using Revrs.Extensions;

namespace AinbLibrary.Structures;

public readonly ref struct AinbNodeConnections(Span<byte> buffer, int offsetsPointer)
{
    private readonly Span<byte> _buffer = buffer;
    private readonly Span<int> _offset = buffer[offsetsPointer..].ReadSpan<int>();

    public readonly ref T ReadConnection<T>(int index) where T : unmanaged
    {
        ref int offset = ref _offset[index];
        return ref _buffer[offset..].Read<T>();
    }
}
