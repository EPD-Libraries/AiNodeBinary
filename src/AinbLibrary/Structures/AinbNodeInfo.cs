using System.Runtime.InteropServices;

namespace AinbLibrary.Structures;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0xA4)]
public struct AinbNodeInfo
{
    public ImmediateParameter IntImmediateParameterInfo;
    public ImmediateParameter BoolImmediateParameterInfo;
    public ImmediateParameter FloatImmediateParameterInfo;
    public ImmediateParameter StringImmediateParameterInfo;
    public ImmediateParameter VectorImmediateParameterInfo;
    public ImmediateParameter PointerImmediateParameterInfo;

    public IOParameter IntIOParameterInfo;
    public IOParameter BoolIOParameterInfo;
    public IOParameter FloatIOParameterInfo;
    public IOParameter StringIOParameterInfo;
    public IOParameter VectorIOParameterInfo;
    public IOParameter PointerIOParameterInfo;

    public Connection BoolOrFloatIOConnectionInfo;
    public Connection UnusedConnectionInfo1;
    public Connection StandardConnectionInfo;
    public Connection ResidentUpdateConnectionInfo;
    public Connection StringIOConnectionInfo;
    public Connection IntIOConnectionInfo;
    public Connection UnusedConnectionInfo2;
    public Connection UnusedConnectionInfo3;
    public Connection UnusedConnectionInfo4;
    public Connection UnusedConnectionInfo5;

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public struct ImmediateParameter
    {
        public int BaseIndex;
        public int Count;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public struct IOParameter
    {
        public int InputBaseIndex;
        public int InputCount;
        public int OutputBaseIndex;
        public int OutputCount;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct Connection
    {
        public byte Count;
        public byte BaseIndex;
    }
}
