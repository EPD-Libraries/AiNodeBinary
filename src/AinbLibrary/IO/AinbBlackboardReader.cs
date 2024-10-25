using AinbLibrary.IO.Structures.Blackboard;
using Revrs;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AinbLibrary.IO;

public ref struct AinbBlackboardReader
{
    public AinbBlackboardEntriesHeader StringsHeader;
    public Span<AinbBlackboardEntry> StringEntries;
    public Span<uint> StringDefaultValues;
    public Span<AinbBlackboardFileReferenceEntry> StringFileReferences;

    public AinbBlackboardEntriesHeader IntsHeader;
    public Span<AinbBlackboardEntry> IntEntries;
    public Span<int> IntDefaultValues;
    public Span<AinbBlackboardFileReferenceEntry> IntFileReferences;

    public AinbBlackboardEntriesHeader FloatsHeader;
    public Span<AinbBlackboardEntry> FloatEntries;
    public Span<float> FloatDefaultValues;
    public Span<AinbBlackboardFileReferenceEntry> FloatFileReferences;

    public AinbBlackboardEntriesHeader BooleansHeader;
    public Span<AinbBlackboardEntry> BooleanEntries;
    public Span<bool> BooleanDefaultValues;
    public Span<AinbBlackboardFileReferenceEntry> BooleanFileReferences;

    public AinbBlackboardEntriesHeader VectorsHeader;
    public Span<AinbBlackboardEntry> VectorEntries;
    public Span<Vector3> VectorDefaultValues;
    public Span<AinbBlackboardFileReferenceEntry> VectorFileReferences;

    public AinbBlackboardEntriesHeader PointersHeader;
    public Span<AinbBlackboardEntry> PointerEntries;
    public Span<AinbBlackboardFileReferenceEntry> PointerFileReferences;

    public AinbBlackboardReader(ref RevrsReader reader)
    {
        StringsHeader = reader.Read<AinbBlackboardEntriesHeader>();
        IntsHeader = reader.Read<AinbBlackboardEntriesHeader>();
        FloatsHeader = reader.Read<AinbBlackboardEntriesHeader>();
        BooleansHeader = reader.Read<AinbBlackboardEntriesHeader>();
        VectorsHeader = reader.Read<AinbBlackboardEntriesHeader>();
        PointersHeader = reader.Read<AinbBlackboardEntriesHeader>();

        StringEntries = reader.ReadSpan<AinbBlackboardEntry>(StringsHeader.Count);
        IntEntries = reader.ReadSpan<AinbBlackboardEntry>(IntsHeader.Count);
        FloatEntries = reader.ReadSpan<AinbBlackboardEntry>(FloatsHeader.Count);
        BooleanEntries = reader.ReadSpan<AinbBlackboardEntry>(BooleansHeader.Count);
        VectorEntries = reader.ReadSpan<AinbBlackboardEntry>(VectorsHeader.Count);
        PointerEntries = reader.ReadSpan<AinbBlackboardEntry>(PointersHeader.Count);

        int defaultValuesOffset = reader.Position;

        StringDefaultValues = reader.ReadSpan<uint>(
            StringsHeader.Count,
            defaultValuesOffset + StringsHeader.Offset);
        IntDefaultValues = reader.ReadSpan<int>(
            IntsHeader.Count,
            defaultValuesOffset + IntsHeader.Offset);
        FloatDefaultValues = reader.ReadSpan<float>(
            FloatsHeader.Count,
            defaultValuesOffset + FloatsHeader.Offset);
        BooleanDefaultValues = reader.ReadSpan<bool>(
            BooleansHeader.Count,
            defaultValuesOffset + BooleansHeader.Offset);
        VectorDefaultValues = reader.ReadSpan<Vector3>(
            VectorsHeader.Count,
            defaultValuesOffset + VectorsHeader.Offset);

        StringFileReferences = reader.ReadSpan<AinbBlackboardFileReferenceEntry>(
            GetFileReferenceCount(StringEntries, StringsHeader.Count));
        IntFileReferences = reader.ReadSpan<AinbBlackboardFileReferenceEntry>(
            GetFileReferenceCount(IntEntries, IntsHeader.Count));
        FloatFileReferences = reader.ReadSpan<AinbBlackboardFileReferenceEntry>(
            GetFileReferenceCount(FloatEntries, FloatsHeader.Count));
        BooleanFileReferences = reader.ReadSpan<AinbBlackboardFileReferenceEntry>(
            GetFileReferenceCount(BooleanEntries, BooleansHeader.Count));
        VectorFileReferences = reader.ReadSpan<AinbBlackboardFileReferenceEntry>(
            GetFileReferenceCount(VectorEntries, VectorsHeader.Count));
        PointerFileReferences = reader.ReadSpan<AinbBlackboardFileReferenceEntry>(
            GetFileReferenceCount(PointerEntries, PointersHeader.Count));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetFileReferenceCount(in Span<AinbBlackboardEntry> entries, int length)
    {
        if (length < 1) {
            return 0;
        }

        int count = entries[0].HasFileReference;
        for (int i = 1; i < length; i++) {
            count += entries[i].HasFileReference;
        }

        return count;
    }
}
