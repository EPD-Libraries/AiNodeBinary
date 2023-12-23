using AiNodeLibrary.Structures;

namespace AiNodeLibrary.Common;

public class AinbNode(string name)
{
    public NodeType Type { get; set; }
    public string Name { get; set; } = name;
    public int Index { get; set; } = -1;

    public NodeFlags Flags { get; set; }

    // TODO: Extended node properties

    public Guid DebugId { get; set; } = Guid.Empty;
}
