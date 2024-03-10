using AinbLibrary.Structures.Blackboard;
using Revrs;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AinbLibrary.Sections;

public ref struct AinbBlackboardSection
{
    public AinbBlackboardParametersEntryHeader StringHeader;
    public Span<AinbBlackboardParametersEntry> StringEntries;
    public Span<uint> StringDefaultValues;
    public Span<AinbBlackboardParametersFileReference> StringFileReferences;

    public AinbBlackboardParametersEntryHeader IntHeader;
    public Span<AinbBlackboardParametersEntry> IntEntries;
    public Span<int> IntDefaultValues;
    public Span<AinbBlackboardParametersFileReference> IntFileReferences;

    public AinbBlackboardParametersEntryHeader FloatHeader;
    public Span<AinbBlackboardParametersEntry> FloatEntries;
    public Span<float> FloatDefaultValues;
    public Span<AinbBlackboardParametersFileReference> FloatFileReferences;

    public AinbBlackboardParametersEntryHeader BoolHeader;
    public Span<AinbBlackboardParametersEntry> BoolEntries;
    public Span<bool> BoolDefaultValues;
    public Span<AinbBlackboardParametersFileReference> BoolFileReferences;

    public AinbBlackboardParametersEntryHeader VectorHeader;
    public Span<AinbBlackboardParametersEntry> VectorEntries;
    public Span<Vector3> VectorDefaultValues;
    public Span<AinbBlackboardParametersFileReference> VectorFileReferences;

    public AinbBlackboardParametersEntryHeader PointerHeader;
    public Span<AinbBlackboardParametersEntry> PointerEntries;
    public Span<AinbBlackboardParametersFileReference> PointerFileReferences;

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

        StringFileReferences = reader.ReadSpan<AinbBlackboardParametersFileReference>(
            GetFileReferenceCount(StringEntries, StringHeader.Count));
        IntFileReferences = reader.ReadSpan<AinbBlackboardParametersFileReference>(
            GetFileReferenceCount(IntEntries, IntHeader.Count));
        FloatFileReferences = reader.ReadSpan<AinbBlackboardParametersFileReference>(
            GetFileReferenceCount(FloatEntries, FloatHeader.Count));
        BoolFileReferences = reader.ReadSpan<AinbBlackboardParametersFileReference>(
            GetFileReferenceCount(BoolEntries, BoolHeader.Count));
        VectorFileReferences = reader.ReadSpan<AinbBlackboardParametersFileReference>(
            GetFileReferenceCount(VectorEntries, VectorHeader.Count));
        PointerFileReferences = reader.ReadSpan<AinbBlackboardParametersFileReference>(
            GetFileReferenceCount(PointerEntries, PointerHeader.Count));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetFileReferenceCount(in Span<AinbBlackboardParametersEntry> entries, int length)
    {
        if (length < 1) {
            return 0;
        }

        int count = entries[0].NameOffsetAndFlags.HasFileReference;
        for (int i = 1; i < length; i++) {
            count += entries[i].NameOffsetAndFlags.HasFileReference;
        }

        return count;
    }
}
