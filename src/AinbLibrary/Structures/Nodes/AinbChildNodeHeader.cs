using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.Nodes;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AinbChildNodeHeader
{
    public byte BoolInputFloatOutputSourceNodeCount;
    public byte BoolInputFloatOutputSourceNodeBaseIndex;
    public byte UnknownConnectionTypeCount_1;
    public byte UnknownConnectionTypeBaseIndex_1;
    public byte StandardChildNodeCount;
    public byte StandardChildNodeBaseIndex;
    public byte ResidentUpdateNodeCount;
    public byte ResidentUpdateBaseIndex;
    public byte StringInputSourceNodeCount;
    public byte StringInputSourceNodeBaseIndex;
    public byte IntInputSourceNodeCount;
    public byte IntInputSourceNodeBaseIndex;
    public byte UnknownConnectionTypeCount_2;
    public byte UnknownConnectionTypeBaseIndex_2;
    public byte UnknownConnectionTypeCount_3;
    public byte UnknownConnectionTypeBaseIndex_3;
    public byte UnknownConnectionTypeCount_4;
    public byte UnknownConnectionTypeBaseIndex_4;
    public byte UnknownConnectionTypeCount_5;
    public byte UnknownConnectionTypeBaseIndex_5;
}