using AinbLibrary.IO.Structures.ImmediateParameters;

namespace AinbLibrary.IO.Structures.AttachmentParameters;

public struct AinbAttachmentEntryParameters
{
    public uint Unknown;

    public AinbImmediateParameterInfo IntImmediateParameterInfo;
    public AinbImmediateParameterInfo BoolImmediateParameterInfo;
    public AinbImmediateParameterInfo FloatImmediateParameterInfo;
    public AinbImmediateParameterInfo StringImmediateParameterInfo;
    public AinbImmediateParameterInfo VectorImmediateParameterInfo;
    public AinbImmediateParameterInfo PointerImmediateParameterInfo;

    public UnkownOffset Unkown1;
    public UnkownOffset Unkown2;
    public UnkownOffset Unkown3;
    public UnkownOffset Unkown4;
    public UnkownOffset Unkown5;
    public UnkownOffset Unkown6;

    public struct UnkownOffset
    {
        public uint Unknown;
        public uint AddressToNextEntry;
    }
}
