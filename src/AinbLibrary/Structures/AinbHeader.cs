using System.Runtime.InteropServices;

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
}
