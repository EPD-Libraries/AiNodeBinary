using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.NodeBodies;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0x90)]
public struct AinbNodeBodiesParameters
{
    public AinbNodeBodiesImmediateParameters IntImmediateParameters;
    public AinbNodeBodiesImmediateParameters BoolImmediateParameters;
    public AinbNodeBodiesImmediateParameters FloatImmediateParameters;
    public AinbNodeBodiesImmediateParameters StringImmediateParameters;
    public AinbNodeBodiesImmediateParameters VectorImmediateParameters;
    public AinbNodeBodiesImmediateParameters PointerImmediateParameters;

    public AinbNodeBodiesIOParameters IntIOParameters;
    public AinbNodeBodiesIOParameters BoolIOParameters;
    public AinbNodeBodiesIOParameters FloatIOParameters;
    public AinbNodeBodiesIOParameters StringIOParameters;
    public AinbNodeBodiesIOParameters VectorIOParameters;
    public AinbNodeBodiesIOParameters PointerIOParameters;
}
