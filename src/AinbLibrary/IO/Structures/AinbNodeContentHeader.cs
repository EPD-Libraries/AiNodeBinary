using AinbLibrary.IO.Structures.ImmediateParameters;
using System.Runtime.InteropServices;

namespace AinbLibrary.IO.Structures;

public struct AinbNodeContentHeader
{
    public AinbImmediateParameterInfo IntImmediateParameterInfo;
    public AinbImmediateParameterInfo BoolImmediateParameterInfo;
    public AinbImmediateParameterInfo FloatImmediateParameterInfo;
    public AinbImmediateParameterInfo StringImmediateParameterInfo;
    public AinbImmediateParameterInfo VectorImmediateParameterInfo;
    public AinbImmediateParameterInfo PointerImmediateParameterInfo;

    public IoParameterInfo IntIoParameterInfo;
    public IoParameterInfo BoolIoParameterInfo;
    public IoParameterInfo FloatIoParameterInfo;
    public IoParameterInfo StringIoParameterInfo;
    public IoParameterInfo VectorIoParameterInfo;
    public IoParameterInfo PointerIoParameterInfo;

    public ConnectionInfo BoolOrFloatIoConnectionInfo;
    public ConnectionInfo UnusedConnectionInfo1;
    public ConnectionInfo StandardConnectionInfo;
    public ConnectionInfo ResidentUpdateConnectionInfo;
    public ConnectionInfo StringIoConnectionInfo;
    public ConnectionInfo IntIoConnectionInfo;
    public ConnectionInfo UnusedConnectionInfo2;
    public ConnectionInfo UnusedConnectionInfo3;
    public ConnectionInfo UnusedConnectionInfo4;
    public ConnectionInfo UnusedConnectionInfo5;

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public struct IoParameterInfo
    {
        public int InputBaseIndex;
        public int InputCount;
        public int OutputBaseIndex;
        public int OutputCount;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct ConnectionInfo
    {
        public byte Count;
        public byte BaseIndex;
    }
}
