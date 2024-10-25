using AinbLibrary.Extensions;
using System.Runtime.InteropServices;
using VYaml.Emitter;

namespace AinbLibrary.Structures;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0x74)]
public struct AinbHeader
{
    public const uint AINB_MAGIC = 0x20424941;

    public uint Magic;
    public uint Version;
    public int FileNameOffset;

    public int CommandCount;
    public int NodeCount;
    public int PreconditionNodeCount;
    public int AttachmentParameterCount;
    public int OutputNodeCount;

    public int BlackboardParametersOffset;
    public int StringPoolOffset;
    public int EnumResolveArrayOffset;
    public int ImmediateParametersOffset;
    public int ResidentUpdateArrayOffset;
    public int IOParametersOffset;
    public int MultiParametersArrayOffset;
    public int AttachmentParametersOffset;
    public int AttachmentParametersIndexArrayOffset;
    public int ExbSectionOffset;
    public int ChildReplacmentTableOffset;
    public int PreconditionNodeArrayOffset;

    /// <summary>
    /// Unused in TotK, always the same as the Resident Update Array Offset
    /// </summary>
    public int UnknownA;

    /// <summary>
    /// Always 0
    /// </summary>
    public int UnknownB;

    /// <summary>
    /// Always 0, used in Splatoon 3/Nintendo Switch Sports
    /// </summary>
    public int UnknownC;

    public int ModulesArrayOffset;
    public int FileCategoryNameOffset;

    /// <summary>
    /// <c>(0 = AI, 1 = Logic, 2 = Sequence)</c>, <i>only TotK</i>
    /// </summary>
    public int FileCategory;

    /// <summary>
    /// Purpose unknown
    /// </summary>
    public int EntryStringsOffset;

    /// <summary>
    /// Unused in TotK
    /// </summary>
    public int UnknownD;

    /// <summary>
    /// Purpose unknown
    /// </summary>
    public int FileIdentificationHashesOffset;

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.WriteString(nameof(Magic));
        emitter.WriteString(Magic.GetString());

        emitter.WriteString(nameof(Version));
        emitter.WriteString(Version.ToString());

        emitter.WriteString(nameof(FileNameOffset));
        emitter.WriteInt32(FileNameOffset);

        emitter.WriteString(nameof(CommandCount));
        emitter.WriteInt32(CommandCount);

        emitter.WriteString(nameof(NodeCount));
        emitter.WriteInt32(NodeCount);

        emitter.WriteString(nameof(PreconditionNodeCount));
        emitter.WriteInt32(PreconditionNodeCount);

        emitter.WriteString(nameof(AttachmentParameterCount));
        emitter.WriteInt32(AttachmentParameterCount);

        emitter.WriteString(nameof(OutputNodeCount));
        emitter.WriteInt32(OutputNodeCount);

        emitter.WriteString(nameof(BlackboardParametersOffset));
        emitter.WriteInt32(BlackboardParametersOffset);

        emitter.WriteString(nameof(StringPoolOffset));
        emitter.WriteInt32(StringPoolOffset);

        emitter.WriteString(nameof(EnumResolveArrayOffset));
        emitter.WriteInt32(EnumResolveArrayOffset);

        emitter.WriteString(nameof(ImmediateParametersOffset));
        emitter.WriteInt32(ImmediateParametersOffset);

        emitter.WriteString(nameof(ResidentUpdateArrayOffset));
        emitter.WriteInt32(ResidentUpdateArrayOffset);

        emitter.WriteString(nameof(IOParametersOffset));
        emitter.WriteInt32(IOParametersOffset);

        emitter.WriteString(nameof(MultiParametersArrayOffset));
        emitter.WriteInt32(MultiParametersArrayOffset);

        emitter.WriteString(nameof(AttachmentParametersOffset));
        emitter.WriteInt32(AttachmentParametersOffset);

        emitter.WriteString(nameof(AttachmentParametersIndexArrayOffset));
        emitter.WriteInt32(AttachmentParametersIndexArrayOffset);

        emitter.WriteString(nameof(ExbSectionOffset));
        emitter.WriteInt32(ExbSectionOffset);

        emitter.WriteString(nameof(ChildReplacmentTableOffset));
        emitter.WriteInt32(ChildReplacmentTableOffset);

        emitter.WriteString(nameof(PreconditionNodeArrayOffset));
        emitter.WriteInt32(PreconditionNodeArrayOffset);

        emitter.WriteString(nameof(UnknownA));
        emitter.WriteInt32(UnknownA);

        emitter.WriteString(nameof(UnknownB));
        emitter.WriteInt32(UnknownB);

        emitter.WriteString(nameof(UnknownC));
        emitter.WriteInt32(UnknownC);

        emitter.WriteString(nameof(ModulesArrayOffset));
        emitter.WriteInt32(ModulesArrayOffset);

        emitter.WriteString(nameof(FileCategoryNameOffset));
        emitter.WriteInt32(FileCategoryNameOffset);

        emitter.WriteString(nameof(FileCategory));
        emitter.WriteInt32(FileCategory);

        emitter.WriteString(nameof(EntryStringsOffset));
        emitter.WriteInt32(EntryStringsOffset);

        emitter.WriteString(nameof(UnknownD));
        emitter.WriteInt32(UnknownD);

        emitter.WriteString(nameof(FileIdentificationHashesOffset));
        emitter.WriteInt32(FileIdentificationHashesOffset);
    }
}
