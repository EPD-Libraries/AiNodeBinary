using AinbLibrary.IO.Structures.AttachmentParameters;
using Revrs;

namespace AinbLibrary.IO;

public ref struct AinbAttachmentReader
{
    public Span<int> Offsets;
    public Span<AinbAttachmentEntry> Entries;
    public Span<AinbAttachmentEntryParameters> EntryParameters;

    public AinbAttachmentReader(ref RevrsReader reader, int count)
    {
        Offsets = reader.ReadSpan<int>(count);
        Entries = reader.ReadSpan<AinbAttachmentEntry>(count);
        EntryParameters = reader.ReadSpan<AinbAttachmentEntryParameters>(count);
    }
}
