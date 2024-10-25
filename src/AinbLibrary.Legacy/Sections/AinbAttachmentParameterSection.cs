using Revrs;

namespace AinbLibrary.Sections;

public ref struct AinbAttachmentParameterSection
{
    public Span<uint> Offsets;

    public AinbAttachmentParameterSection(ref RevrsReader reader, int count)
    {
        Offsets = reader.ReadSpan<uint>(count);
    }
}
