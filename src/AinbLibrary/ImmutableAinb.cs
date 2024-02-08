using AinbLibrary.Sections;
using AinbLibrary.Structures;
using Revrs;

namespace AinbLibrary;

public ref struct ImmutableAinb
{
    public AinbHeader Header;
    public Span<AinbCommand> Commands;
    public Span<AinbNode> Nodes;
    public AinbBlackboardSection BlackboardSection;
    public Span<byte> NodeBodyBlock;
    public AinbAttachmentParameterSection AttachmentParameterSection;

    public ImmutableAinb(ref RevrsReader reader)
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

        NodeBodyBlock = reader.Read(Header.AttachmentParametersOffset - reader.Position);

        AttachmentParameterSection = new(ref reader, Header.AttachmentParameterCount);
    }
}