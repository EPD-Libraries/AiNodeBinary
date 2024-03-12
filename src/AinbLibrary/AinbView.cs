using AinbLibrary.Sections;
using AinbLibrary.Structures;
using Revrs;
using System.Runtime.InteropServices.Marshalling;

namespace AinbLibrary;

public ref struct AinbView
{
    public AinbHeader Header;
    public Span<AinbCommand> Commands;
    public Span<AinbNode> Nodes;
    public AinbBlackboardSection BlackboardSection;
    public AinbNodeInfoSection NodeInfoSection;
    public AinbAttachmentParameterSection AttachmentParameterSection;
    public Span<byte> StringPool;

    public AinbView(ref RevrsReader reader)
    {
        Header = reader.Read<AinbHeader>();

        if (Header.Magic != AinbHeader.AINB_MAGIC) {
            throw new InvalidDataException("Invalid AINB magic!");
        }

        if (Header.Version is not 0x407 or 0x404) {
            throw new InvalidDataException($"Unsupported version: {Header.Version:x2}");
        }

        Commands = reader.ReadSpan<AinbCommand>(Header.CommandCount);
        Nodes = reader.ReadSpan<AinbNode>(Header.NodeCount);
        BlackboardSection = new(ref reader);
        NodeInfoSection = new(ref reader);
        AttachmentParameterSection = new(ref reader, Header.AttachmentParameterCount);

        StringPool = reader.ReadSpan<byte>(reader.Length - Header.StringPoolOffset, Header.StringPoolOffset);
    }

    public unsafe readonly string GetString(int offset)
    {
        fixed (byte* ptr = StringPool[offset..]) {
            return Utf8StringMarshaller.ConvertToManaged(ptr)
                ?? string.Empty;
        }
    }
}