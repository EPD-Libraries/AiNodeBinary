using AinbLibrary.Structures.Blackboard;
using Revrs;
using System.Numerics;

namespace AinbLibrary.Sections;

public ref struct AinbBlackboardSection
{
    public AinbBlackboardParametersEntryHeader StringHeader;
    public Span<AinbBlackboardParametersEntry> StringEntries;
    public Span<uint> StringDefaultValues;

    public AinbBlackboardParametersEntryHeader IntHeader;
    public Span<AinbBlackboardParametersEntry> IntEntries;
    public Span<int> IntDefaultValues;

    public AinbBlackboardParametersEntryHeader FloatHeader;
    public Span<AinbBlackboardParametersEntry> FloatEntries;
    public Span<float> FloatDefaultValues;

    public AinbBlackboardParametersEntryHeader BoolHeader;
    public Span<AinbBlackboardParametersEntry> BoolEntries;
    public Span<bool> BoolDefaultValues;

    public AinbBlackboardParametersEntryHeader VectorHeader;
    public Span<AinbBlackboardParametersEntry> VectorEntries;
    public Span<Vector3> VectorDefaultValues;

    public AinbBlackboardParametersEntryHeader PointerHeader;
    public Span<AinbBlackboardParametersEntry> PointerEntries;

    public Span<AinbBlackboardParametersFileReference> FileReferences;

    public AinbBlackboardSection(ref RevrsReader reader)
    {
        StringHeader = reader.Read<AinbBlackboardParametersEntryHeader>();
        IntHeader = reader.Read<AinbBlackboardParametersEntryHeader>();
        FloatHeader = reader.Read<AinbBlackboardParametersEntryHeader>();
        BoolHeader = reader.Read<AinbBlackboardParametersEntryHeader>();
        VectorHeader = reader.Read<AinbBlackboardParametersEntryHeader>();
        PointerHeader = reader.Read<AinbBlackboardParametersEntryHeader>();

        StringEntries = reader.ReadSpan<AinbBlackboardParametersEntry>(StringHeader.Count);
        IntEntries = reader.ReadSpan<AinbBlackboardParametersEntry>(IntHeader.Count);
        FloatEntries = reader.ReadSpan<AinbBlackboardParametersEntry>(FloatHeader.Count);
        BoolEntries = reader.ReadSpan<AinbBlackboardParametersEntry>(BoolHeader.Count);
        VectorEntries = reader.ReadSpan<AinbBlackboardParametersEntry>(VectorHeader.Count);
        PointerEntries = reader.ReadSpan<AinbBlackboardParametersEntry>(PointerHeader.Count);

        int defaultValuesOffset = reader.Position;

        StringDefaultValues = reader.ReadSpan<uint>(
            StringHeader.Count,
            defaultValuesOffset + StringHeader.Offset);
        IntDefaultValues = reader.ReadSpan<int>(
            IntHeader.Count,
            defaultValuesOffset + IntHeader.Offset);
        FloatDefaultValues = reader.ReadSpan<float>(
            FloatHeader.Count,
            defaultValuesOffset + FloatHeader.Offset);
        BoolDefaultValues = reader.ReadSpan<bool>(
            BoolHeader.Count,
            defaultValuesOffset + BoolHeader.Offset);
        VectorDefaultValues = reader.ReadSpan<Vector3>(
            VectorHeader.Count,
            defaultValuesOffset + VectorHeader.Offset);

        // TODO: there's probably a better way to do this

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
            ? reader.ReadSpan<AinbBlackboardParametersFileReference>(totalFileReferenceCount) : [];
    }
}
