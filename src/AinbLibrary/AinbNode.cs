using AinbLibrary.Connections;
using System.Diagnostics.CodeAnalysis;

namespace AinbLibrary;

public class AinbNode : IAinbNode
{
    public required AinbNodeType Type { get; set; }
    public AinbNodeFlags Flags { get; set; }
    public string? CustomTypeName { get; set; }
    public IList<IAinbConnection> Connections { get; set; } = [];
    public Guid Id { get; set; }

    public AinbNode()
    {
    }

    [SetsRequiredMembers]
    public AinbNode(AinbNodeType type)
    {
        Type = type;
    }
}
