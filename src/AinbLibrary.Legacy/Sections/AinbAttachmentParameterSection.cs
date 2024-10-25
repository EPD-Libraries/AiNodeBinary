using Revrs;

namespace AinbLibrary.Legacy.Sections;

public ref struct AinbAttachmentParameterSection
{
    public Span<uint> Offsets;

    public AinbAttachmentParameterSection(ref RevrsReader reader, int count)
    {
        Offsets = reader.ReadSpan<uint>(count);
    }
}
