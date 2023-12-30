using AinbLibrary.Common;
using Revrs;

namespace AinbLibrary;

public class Ainb(string name, string category, int version = 0x407)
{
    public string Name { get; set; } = name;
    public string Category { get; set; } = category;
    public int Version { get; set; } = version;

    public Dictionary<string, dynamic> LocalBlackboard { get; init; } = [];

    public Dictionary<string, AinbCommand> Commands { get; init; } = [];
    public Dictionary<string, AinbNode> Nodes { get; init; } = [];
    public Dictionary<string, EmbeddedAinb> EmbeddedAiNodeFiles { get; init; } = [];
    public Dictionary<string, uint> Hashes { get; init; } = [];

    public static Ainb FromBinary(Span<byte> data)
    {
        RevrsReader reader = new(data, Endianness.Little);
        ImmutableAinb immutable = new(ref reader);
        return FromImmutable(ref immutable);
    }

    public static Ainb FromImmutable(ref ImmutableAinb immutable)
    {
        throw new NotImplementedException();
    }
}
