using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.NodeBodies;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
public struct AinbNodeBodiesIOParameters
{
    public uint InputBaseIndex;
    public uint InputCount;
    public uint OutputBaseIndex;
    public uint OutputCount;
}
