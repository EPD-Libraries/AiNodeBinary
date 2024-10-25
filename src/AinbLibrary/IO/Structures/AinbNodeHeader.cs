using System.Runtime.InteropServices;

namespace AinbLibrary.IO.Structures;

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct AinbNodeHeader
{
    public AinbNodeType NodeType;
    public ushort NodeIndex;
    public ushort AttachmentParameterCount;
    public AinbNodeFlags NodeFlags;
    public int UserDefinedNodeTypeNameOffset;
    public uint NameHash;
    public uint UnknownA;
    public int NodeContentOffset;
    public ushort ExbFunctionCount;
    public ushort ExbIOFieldSize;
    public ushort MultiParameterCount;
    public ushort UnknownB;
    public int BaseAttachmentParameterIndex;
    public ushort BasePreconditionNode; // is this an index?
    public ushort PreconditionNodeCount;

    /// <summary>
    /// Relative to the start of the file.
    /// </summary>
    public ushort SectionEntryOffset;
    public ushort UnknownC;
    public Guid Id;
}
