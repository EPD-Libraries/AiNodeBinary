using System.Numerics;
using System.Runtime.CompilerServices;
using AinbLibrary.Legacy.Structures.Blackboard;
using Revrs;
using VYaml.Emitter;

namespace AinbLibrary.Legacy.Sections;

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

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.WriteString("Blackboard");
        emitter.BeginMapping();
        {
            emitter.WriteString("String");
            emitter.BeginMapping();
            {
                StringHeader.EmitYaml(ref emitter);

                emitter.WriteString("Entries");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersEntry entry in StringEntries) {
                        entry.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("Default Values");
                emitter.BeginSequence();
                {
                    foreach (uint value in StringDefaultValues) {
                        emitter.WriteUInt32(value);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("References");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersFileReference reference in StringFileReferences) {
                        reference.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();
            }
            emitter.EndMapping();

            emitter.WriteString("Int");
            emitter.BeginMapping();
            {
                IntHeader.EmitYaml(ref emitter);

                emitter.WriteString("Entries");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersEntry entry in IntEntries) {
                        entry.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("Default Values");
                emitter.BeginSequence();
                {
                    foreach (int value in IntDefaultValues) {
                        emitter.WriteInt32(value);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("References");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersFileReference reference in IntFileReferences) {
                        reference.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();
            }
            emitter.EndMapping();

            emitter.WriteString("Float");
            emitter.BeginMapping();
            {
                FloatHeader.EmitYaml(ref emitter);

                emitter.WriteString("Entries");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersEntry entry in FloatEntries) {
                        entry.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("Default Values");
                emitter.BeginSequence();
                {
                    foreach (float value in FloatDefaultValues) {
                        emitter.WriteFloat(value);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("References");
                emitter.BeginSequence();
                {
                    foreach (var reference in FloatFileReferences) {
                        reference.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();
            }
            emitter.EndMapping();

            emitter.WriteString("Bool");
            emitter.BeginMapping();
            {
                BoolHeader.EmitYaml(ref emitter);

                emitter.WriteString("Entries");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersEntry entry in BoolEntries) {
                        entry.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("Default Values");
                emitter.BeginSequence();
                {
                    foreach (bool value in BoolDefaultValues) {
                        emitter.WriteBool(value);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("References");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersFileReference reference in BoolFileReferences) {
                        reference.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();
            }
            emitter.EndMapping();

            emitter.WriteString("Vector");
            emitter.BeginMapping();
            {
                VectorHeader.EmitYaml(ref emitter);

                emitter.WriteString("Entries");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersEntry entry in VectorEntries) {
                        entry.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("Default Values");
                emitter.BeginSequence();
                {
                    foreach (Vector3 value in VectorDefaultValues) {
                        emitter.BeginMapping(MappingStyle.Flow);
                        emitter.WriteString(nameof(value.X));
                        emitter.WriteFloat(value.X);
                        emitter.WriteString(nameof(value.Y));
                        emitter.WriteFloat(value.Y);
                        emitter.WriteString(nameof(value.Z));
                        emitter.WriteFloat(value.Z);
                        emitter.EndMapping();
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("References");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersFileReference reference in VectorFileReferences) {
                        reference.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();
            }
            emitter.EndMapping();

            emitter.WriteString("Pointer");
            emitter.BeginMapping();
            {
                PointerHeader.EmitYaml(ref emitter);

                emitter.WriteString("Entries");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersEntry entry in PointerEntries) {
                        entry.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();

                emitter.WriteString("References");
                emitter.BeginSequence();
                {
                    foreach (AinbBlackboardParametersFileReference reference in PointerFileReferences) {
                        reference.EmitYaml(ref emitter);
                    }
                }
                emitter.EndSequence();
            }
            emitter.EndMapping();

        }
        emitter.EndMapping();
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
