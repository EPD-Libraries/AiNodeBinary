namespace AinbLibrary.IO.Structures.AttachmentParameters;

public struct AinbAttachmentEntry
{
    public int NameOffset;
    public int ParametersOffset;
    public ushort ExbFunctionCount;
    public ushort ExbIoFieldSize;
    public uint NameHash;
}
