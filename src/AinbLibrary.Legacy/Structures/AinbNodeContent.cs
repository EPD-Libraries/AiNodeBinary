using Revrs;

namespace AinbLibrary.Legacy.Structures;

public ref struct AinbNodeContent
{
    public AinbNodeInfo Info;
    public AinbNodeConnections Connections;

    public AinbNodeContent(Span<byte> buffer)
    {
        RevrsReader reader = new(buffer);
        Info = reader.Read<AinbNodeInfo>();
        Connections = new(buffer, reader.Position);
    }
}
