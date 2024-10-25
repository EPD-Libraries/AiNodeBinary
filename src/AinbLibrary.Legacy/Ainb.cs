using AinbLibrary.Common;
using AinbLibrary.Structures;
using Revrs;

namespace AinbLibrary;

public class Ainb
{
    public List<AiNode> Nodes { get; init; } = [];

    public static Ainb FromBinary(Span<byte> data)
    {
        RevrsReader reader = new(data, Endianness.Little);
        AinbView immutable = new(ref reader);
        return FromAinbView(ref immutable);
    }

    public static Ainb FromAinbView(ref AinbView ainb)
    {
        Ainb result = new();

        foreach (AinbNode node in ainb.Nodes) {
            result.Nodes.Add(AiNode.FromNodeView(ainb, node));
        }

        return result;
    }
}
