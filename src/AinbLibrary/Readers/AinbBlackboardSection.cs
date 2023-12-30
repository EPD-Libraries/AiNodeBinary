using AinbLibrary.Structures.Blackboard;
using Revrs;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace AinbLibrary.Readers;

public ref struct AinbBlackboardSection
{
    public static readonly string[] DataTypes = [
        "String",
        "Int",
        "Float",
        "Bool",
        "Vector",
        "Pointer"
    ];

    public AinbBlackboardEntryHeader StringHeader;
    public Span<AinbBlackboardEntry> StringEntries;
    public Span<uint> StringDefaultValues;

    public AinbBlackboardEntryHeader IntHeader;
    public Span<AinbBlackboardEntry> IntEntries;
    public Span<int> IntDefaultValues;

    public AinbBlackboardEntryHeader FloatHeader;
    public Span<AinbBlackboardEntry> FloatEntries;
    public Span<float> FloatDefaultValues;

    public AinbBlackboardEntryHeader BoolHeader;
    public Span<AinbBlackboardEntry> BoolEntries;
    public Span<bool> BoolDefaultValues;

    public AinbBlackboardEntryHeader VectorHeader;
    public Span<AinbBlackboardEntry> VectorEntries;
    public Span<Vector3> VectorDefaultValues;

    public AinbBlackboardEntryHeader PointerHeader;
    public Span<AinbBlackboardEntry> PointerEntries;

    public Span<AinbBlackboardFileReference> FileReferences;

    public AinbBlackboardSection(ref RevrsReader reader)
    {
        StringHeader = reader.Read<AinbBlackboardEntryHeader>();
        IntHeader = reader.Read<AinbBlackboardEntryHeader>();
        FloatHeader = reader.Read<AinbBlackboardEntryHeader>();
        BoolHeader = reader.Read<AinbBlackboardEntryHeader>();
        VectorHeader = reader.Read<AinbBlackboardEntryHeader>();
        PointerHeader = reader.Read<AinbBlackboardEntryHeader>();

        StringEntries = StringHeader.Count == 0 ? []
            : reader.ReadSpan<AinbBlackboardEntry>(StringHeader.Count);
        IntEntries = IntHeader.Count == 0 ? []
            : reader.ReadSpan<AinbBlackboardEntry>(IntHeader.Count);
        FloatEntries = FloatHeader.Count == 0 ? []
            : reader.ReadSpan<AinbBlackboardEntry>(FloatHeader.Count);
        BoolEntries = BoolHeader.Count == 0 ? []
            : reader.ReadSpan<AinbBlackboardEntry>(BoolHeader.Count);
        VectorEntries = VectorHeader.Count == 0 ? []
            : reader.ReadSpan<AinbBlackboardEntry>(VectorHeader.Count);
        PointerEntries = PointerHeader.Count == 0 ? []
            : reader.ReadSpan<AinbBlackboardEntry>(PointerHeader.Count);

        int defaultValuesStartOffset = reader.Position;

        StringDefaultValues = reader.ReadSpan<uint>(
            StringHeader.Count,
            defaultValuesStartOffset + StringHeader.Offset);
        IntDefaultValues = reader.ReadSpan<int>(
            IntHeader.Count,
            defaultValuesStartOffset + IntHeader.Offset);
        FloatDefaultValues = reader.ReadSpan<float>(
            FloatHeader.Count,
            defaultValuesStartOffset + FloatHeader.Offset);
        BoolDefaultValues = reader.ReadSpan<bool>(
            BoolHeader.Count,
            defaultValuesStartOffset + BoolHeader.Offset);
        VectorDefaultValues = reader.ReadSpan<Vector3>(
            VectorHeader.Count,
            defaultValuesStartOffset + VectorHeader.Offset);

        int totalFileReferenceCount = 0;

        foreach (var entry in StringEntries) {
            if (entry.NameOffsetAndFlags.HasFileReference) {
                totalFileReferenceCount++;
            }
        }
        foreach (var entry in IntEntries) {
            if (entry.NameOffsetAndFlags.HasFileReference) {
                totalFileReferenceCount++;
            }
        }
        foreach (var entry in FloatEntries) {
            if (entry.NameOffsetAndFlags.HasFileReference) {
                totalFileReferenceCount++;
            }
        }
        foreach (var entry in BoolEntries) {
            if (entry.NameOffsetAndFlags.HasFileReference) {
                totalFileReferenceCount++;
            }
        }
        foreach (var entry in VectorEntries) {
            if (entry.NameOffsetAndFlags.HasFileReference) {
                totalFileReferenceCount++;
            }
        }
        foreach (var entry in PointerEntries) {
            if (entry.NameOffsetAndFlags.HasFileReference) {
                totalFileReferenceCount++;
            }
        }

        FileReferences = totalFileReferenceCount != 0
            ? reader.ReadSpan<AinbBlackboardFileReference>(totalFileReferenceCount) : [];
    }
}
