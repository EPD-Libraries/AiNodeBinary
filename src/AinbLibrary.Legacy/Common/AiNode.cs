using AinbLibrary.Legacy.Structures;
using AinbLibrary.Legacy.Structures.Connections;

namespace AinbLibrary.Legacy.Common;

public class AiNode
{
    public AiNodeType Type { get; set; }
    public required uint NameHash { get; set; }
    public required string CustomTypeName { get; set; }
    public int Index { get; set; } = -1;
    public NodeFlags Flags { get; set; }
    public IList<AiConnection> BoolOrFloatIoConnections { get; set; } = [];
    public IList<AiConnection> StandardConnections { get; set; } = [];
    public IList<AiConnection> ResidentUpdateConnections { get; set; } = [];
    public IList<AiConnection> StringIoConnections { get; set; } = [];
    public IList<AiConnection> IntIoConnections { get; set; } = [];
    public Guid Id { get; set; } = Guid.Empty;

    public static AiNode FromNodeView(AinbView ainb, AinbNode node)
    {
        AiNode result = new() {
            Type = node.NodeType,
            NameHash = node.NameHash,
            CustomTypeName = ainb.GetString(node.UserDefinedNodeTypeNameOffset),
            Index = node.NodeIndex,
            Flags = node.NodeFlags,
            Id = node.Id
        };

        AinbNodeContent content = ainb.NodeInfoSection[node];

        FillConnections<AinbIoNodeConnection>(ainb,
            node,
            content,
            content.Info.BoolOrFloatIOConnectionInfo,
            result.BoolOrFloatIoConnections);
        FillConnections(ainb,
            node,
            content,
            content.Info.StandardConnectionInfo,
            result.StandardConnections);
        FillConnections(ainb,
            node,
            content,
            content.Info.ResidentUpdateConnectionInfo,
            result.ResidentUpdateConnections);
        FillConnections<AinbIoNodeConnection>(ainb,
            node,
            content,
            content.Info.StringIOConnectionInfo,
            result.StringIoConnections);
        FillConnections<AinbIoNodeConnection>(ainb,
            node,
            content,
            content.Info.IntIOConnectionInfo,
            result.IntIoConnections);

        return result;
    }

    private static void FillConnections<T>(AinbView ainb, AinbNode node, AinbNodeContent nodeContent, AinbNodeInfo.Connection connectionInfo, IList<AiConnection> connections) where T : unmanaged
    {
        for (int i = 0; i < connectionInfo.Count; i++) {
            connections.Add(
                AiConnection.FromStruct(ainb, nodeContent.Connections.ReadConnection<T>(connectionInfo.BaseIndex + i))
            );
        }
    }
}
