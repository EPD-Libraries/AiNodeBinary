using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0x10)]
public struct AinbBlackboardParametersFileReference
{
    public uint FilePathOffset;
    public uint FilePathHash;
    public uint UnknownHashA;
    public uint UnknownHashB;
}
