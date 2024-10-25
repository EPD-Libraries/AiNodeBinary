using System.Runtime.InteropServices;

namespace AinbLibrary.IO.Structures.ImmediateParameters;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
public struct AinbImmediateParameterInfo
{
    public int BaseIndex;
    public int Count;
}
