
using AinbLibrary.Blackboard;
using AinbLibrary.IO;
using Revrs;

namespace AinbLibrary;

public class Ainb : IAinb
{
    public required string Name { get; set; }
    public AinbVersion Version { get; set; }
    public IList<IAinbCommand> Commands { get; set; } = [];
    public IAinbBlackboard Blackboard { get; set; }
    public IList<IAinbNode> Nodes { get; set; } = [];

    public static T FromBinary<T>(in Span<byte> data) where T : IAinb, new()
    {
        RevrsReader reader = new(data);
        AinbReader ainbReader = new(ref reader);
        return FromBinary<T>(ref ainbReader);
    }
    
    public static T FromBinary<T>(ref AinbReader reader) where T : IAinb, new()
    {
        T ainb = new();
        
        // TODO: Fill ainb...

        return ainb;
    }
}
