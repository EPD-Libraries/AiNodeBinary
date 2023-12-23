using AiNodeLibrary.Structures.Blackboard;
using Revrs;

namespace AiNodeLibrary.Readers;

public readonly ref struct AinbBlackboardSection
{
    public static readonly string[] DataTypes = [
        "String",
        "Int",
        "Float",
        "Bool",
        "Vector",
        "Pointer"
    ];

    public readonly Span<AinbBlackboardEntryHeader> Headers;
    public readonly Span<AinbBlackboardEntry> Entries;

    public AinbBlackboardSection(ref RevrsReader reader)
    {
        Headers = reader.ReadSpan<AinbBlackboardEntryHeader>(DataTypes.Length);

        int aggregateEntryCount = 0;
        foreach (var header in Headers) {
            aggregateEntryCount += header.Count;
        }

        Entries = reader.ReadSpan<AinbBlackboardEntry>(aggregateEntryCount);
    }
}
