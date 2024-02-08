using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.NodeBodies;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x14)]
public struct AinbNodeBodiesChildNodeHeader
{
    /// <summary>
    /// Bool/float Input Source Node/Output Source Node Count
    /// </summary>
    public Entry BoolOrFloatInputSourceNode;

    public Entry UnknownConnection1;
    public Entry StandardChildNode;
    public Entry ResidentUpdateNode;
    public Entry StringInputSourceNode;
    public Entry IntInputSourceNode;
    public Entry UnknownConnection2;
    public Entry UnknownConnection3;
    public Entry UnknownConnection4;
    public Entry UnknownConnection5;

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 2)]
    public struct Entry
    {
        public byte Count;
        public byte BaseIndex;
    }
}