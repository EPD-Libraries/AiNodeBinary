using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.NodeBodies;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
public struct AinbNodeBodiesImmediateParameters
{
    public int BaseIndex;
    public int Count;
}
