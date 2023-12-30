using AinbLibrary.Structures.Nodes;
using Revrs;

namespace AinbLibrary.Readers;

public ref struct AinbNodeBodySection
{
    public AinbNodeParameterHeader ParameterHeader;
    public AinbChildNodeHeader ChildNodeHeader;

    public Span<AinbChildNode> BoolInputFloatOutputSourceNodes;
    public Span<AinbChildNode> UnknownConnectionTypeNodes_1;
    public Span<AinbChildNode> StandardChildNodes;
    public Span<AinbChildNode> ResidentUpdateNodes;
    public Span<AinbChildNode> StringInputSourceNodes;
    public Span<AinbChildNode> IntInputSourceNodes;
    public Span<AinbChildNode> UnknownConnectionTypeNodes_2;
    public Span<AinbChildNode> UnknownConnectionTypeNodes_3;
    public Span<AinbChildNode> UnknownConnectionTypeNodes_4;
    public Span<AinbChildNode> UnknownConnectionTypeNodes_5;

    public AinbNodeBodySection(ref RevrsReader reader)
    {
        ParameterHeader = reader.Read<AinbNodeParameterHeader>();
        ChildNodeHeader = reader.Read<AinbChildNodeHeader>();

        BoolInputFloatOutputSourceNodes = ChildNodeHeader.BoolInputFloatOutputSourceNodeCount == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.BoolInputFloatOutputSourceNodeCount);
        StandardChildNodes = ChildNodeHeader.StandardChildNodeCount == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.StandardChildNodeCount);
        ResidentUpdateNodes = ChildNodeHeader.ResidentUpdateNodeCount == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.ResidentUpdateNodeCount);
        StringInputSourceNodes = ChildNodeHeader.StringInputSourceNodeCount == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.StringInputSourceNodeCount);
        IntInputSourceNodes = ChildNodeHeader.IntInputSourceNodeCount == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.IntInputSourceNodeCount);
        UnknownConnectionTypeNodes_1 = ChildNodeHeader.UnknownConnectionTypeCount_1 == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.UnknownConnectionTypeCount_1);
        UnknownConnectionTypeNodes_2 = ChildNodeHeader.UnknownConnectionTypeCount_2 == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.UnknownConnectionTypeCount_2);
        UnknownConnectionTypeNodes_3 = ChildNodeHeader.UnknownConnectionTypeCount_3 == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.UnknownConnectionTypeCount_3);
        UnknownConnectionTypeNodes_4 = ChildNodeHeader.UnknownConnectionTypeCount_4 == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.UnknownConnectionTypeCount_4);
        UnknownConnectionTypeNodes_5 = ChildNodeHeader.UnknownConnectionTypeCount_5 == 0 ? []
            : reader.ReadSpan<AinbChildNode>(ChildNodeHeader.UnknownConnectionTypeCount_5);
    }
}
