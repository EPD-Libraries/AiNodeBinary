using System.Runtime.CompilerServices;
using AinbLibrary.Legacy.Structures;
using Revrs;

namespace AinbLibrary.Legacy.Sections;

public readonly ref struct AinbNodeInfoSection
{
    private readonly Span<byte> _buffer;

    public AinbNodeInfoSection(ref RevrsReader reader)
    {
        _buffer = reader.Data;
    }

    public readonly AinbNodeContent this[AinbNode node] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => new(_buffer[node.NodeInfoOffset..]);
    }
}
