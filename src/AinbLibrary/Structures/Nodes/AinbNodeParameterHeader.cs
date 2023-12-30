using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.Nodes;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct AinbNodeParameterHeader
{
    public uint IntImmediateParameterBaseIndex;
    public uint IntImmediateParameterCount;
    public uint BoolImmediateParameterBaseIndex;
    public uint BoolImmediateParameterCount;
    public uint FloatImmediateParameterBaseIndex;
    public uint FloatImmediateParameterCount;
    public uint StringImmediateParameterBaseIndex;
    public uint StringImmediateParameterCount;
    public uint Vector3fImmediateParameterBaseIndex;
    public uint Vector3fImmediateParameterCount;
    public uint PointerImmediateParameterBaseIndex;
    public uint PointerImmediateParameterCount;
    public uint IntInputParameterBaseIndex;
    public uint IntInputParameterCount;
    public uint IntOutputParameterBaseIndex;
    public uint IntOutputParameterCount;
    public uint BoolInputParameterBaseIndex;
    public uint BoolInputParameterCount;
    public uint BoolOutputParameterBaseIndex;
    public uint BoolOutputParameterCount;
    public uint FloatInputParameterBaseIndex;
    public uint FloatInputParameterCount;
    public uint FloatOutputParameterBaseIndex;
    public uint FloatOutputParameterCount;
    public uint StringInputParameterBaseIndex;
    public uint StringInputParameterCount;
    public uint StringOutputParameterBaseIndex;
    public uint StringOutputParameterCount;
    public uint Vector3fInputParameterBaseIndex;
    public uint Vector3fInputParameterCount;
    public uint Vector3fOutputParameterBaseIndex;
    public uint Vector3fOutputParameterCount;
    public uint PointerInputParameterBaseIndex;
    public uint PointerInputParameterCount;
    public uint PointerOutputParameterBaseIndex;
    public uint PointerOutputParameterCount;
}
