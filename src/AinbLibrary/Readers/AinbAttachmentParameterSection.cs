using Revrs;

namespace AinbLibrary.Readers;

public ref struct AinbAttachmentParameterSection
{
    public Span<uint> Offsets;

    public AinbAttachmentParameterSection(ref RevrsReader reader, int count)
    {
        Offsets = reader.ReadSpan<uint>(count);
    }
}
