using System.Runtime.InteropServices;

namespace AinbLibrary.IO.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0x10)]
public struct AinbBlackboardFileReferenceEntry
{
    public int FileNameOffset;
    public int FileNameHash;
    public int UnknownHashA;
    public int UnknownHashB;
}
