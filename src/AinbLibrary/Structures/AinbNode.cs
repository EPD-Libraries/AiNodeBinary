using System.Runtime.InteropServices;
using VYaml.Emitter;

namespace AinbLibrary.Structures;

public enum AiNodeType : ushort
{
    /// <summary>
    /// Custom node type, definition in NodeDefinition.
    /// </summary>
    UserDefined = 0,

    /// <summary>
    /// Conditionally links to a node depending on the value of a signed int.
    /// </summary>
    Element_S32Selector = 1,

    /// <summary>
    /// Links to nodes sequentially in the order listed.
    /// </summary>
    Element_Sequential = 2,

    /// <summary>
    /// Links simultaneously to multiple nodes.
    /// </summary>
    Element_Simultaneous = 3,

    /// <summary>
    /// Conditionally links to a node depending on the value of 32-bit float.
    /// </summary>
    Element_F32Selector = 4,

    /// <summary>
    /// Conditionally links to a node depending on the value of a string.
    /// </summary>
    Element_StringSelector = 5,

    /// <summary>
    /// Links to a node randomly.
    /// </summary>
    Element_RandomSelector = 6,

    /// <summary>
    /// Conditionally links to a node depending on the value of a bool.
    /// </summary>
    Element_BoolSelector = 7,

    /// <summary>
    /// See Resident Update Array.
    /// </summary>
    Element_Fork = 8,

    /// <summary>
    /// See Resident Update Array.
    /// </summary>
    Element_Join = 9,

    /// <summary>
    /// Displays a debug message.
    /// </summary>
    Element_Alert = 10,

    /// <summary>
    /// Passes values to and from EXB commands.
    /// </summary>
    Element_Expression = 20,

    /// <summary>
    /// Passes a signed int as output to another node as input.
    /// </summary>
    Element_ModuleIF_Input_S32 = 100,

    /// <summary>
    /// Passes a 32-bit float as output to another node as input.
    /// </summary>
    Element_ModuleIF_Input_F32 = 101,

    /// <summary>
    /// Passes a vector3f as output to another node as input.
    /// </summary>
    Element_ModuleIF_Input_Vec3f = 102,

    /// <summary>
    /// Passes a string as output to another node as input.
    /// </summary>
    Element_ModuleIF_Input_String = 103,

    /// <summary>
    /// Passes a boolean int as output to another node as input.
    /// </summary>
    Element_ModuleIF_Input_Bool = 104,

    /// <summary>
    /// Passes a pointer as output to another node as input.
    /// </summary>
    Element_ModuleIF_Input_Ptr = 105,

    /// <summary>
    /// Passes a signed int as output to another node as output.
    /// </summary>
    Element_ModuleIF_Output_S32 = 200,

    /// <summary>
    /// Passes a 32-bit float as output to another node as output.
    /// </summary>
    Element_ModuleIF_Output_F32 = 201,

    /// <summary>
    /// Passes a vector3f as output to another node as output.
    /// </summary>
    Element_ModuleIF_Output_Vec3f = 202,

    /// <summary>
    /// Passes a string as output to another node as output.
    /// </summary>
    Element_ModuleIF_Output_String = 203,

    /// <summary>
    /// Passes a boolean int as output to another node as output.
    /// </summary>
    Element_ModuleIF_Output_Bool = 204,

    /// <summary>
    /// Passes a pointer as output to another node as output.
    /// </summary>
    Element_ModuleIF_Output_Ptr = 205,

    /// <summary>
    /// Unsure, appears to just be a node connected to a ModuleIF node as a child node.
    /// </summary>
    Element_ModuleIF_Child = 300,

    /// <summary>
    /// Termination node.
    /// </summary>
    Element_StateEnd = 400,

    /// <summary>
    /// Changes when child nodes are run (Enter - first time visiting a node, Update - every frame, Leave - ran upon leaving the node).
    /// </summary>
    Element_SplitTiming = 500,
}

[Flags]
public enum NodeFlags : byte
{
    None = 0,
    IsPreconditionNode = 1,
    IsExternalFile = 2,
    IsResidentNode = 4
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct AinbNode
{
    public AiNodeType NodeType;
    public ushort NodeIndex;
    public ushort AttachmentParameterCount;
    public NodeFlags NodeFlags;
    public int UserDefinedNodeTypeNameOffset;
    public uint NameHash;
    public uint UnknownA;

    /// <summary>
    /// Relative to the start of the file.
    /// </summary>
    public int NodeInfoOffset;

    public ushort ExbFunctionCount;
    public ushort ExbIOFieldSize;
    public ushort MultiParameterCount;
    public ushort UnknownB;
    public int BaseAttachmentParameterIndex;
    public ushort BasePreconditionNode; // is this an index?
    public ushort PreconditionNodeCount;

    /// <summary>
    /// Relative to the start of the file.
    /// </summary>
    public ushort SectionEntryOffset;
    public ushort UnknownC;
    public Guid Id;

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.BeginMapping();
        {
            emitter.WriteString(nameof(NodeType));
            emitter.WriteString(NodeType.ToString());

            emitter.WriteString(nameof(NodeIndex));
            emitter.WriteInt32(NodeIndex);

            emitter.WriteString(nameof(AttachmentParameterCount));
            emitter.WriteInt32(AttachmentParameterCount);

            emitter.WriteString(nameof(NodeFlags));
            emitter.WriteString(NodeFlags.ToString());

            emitter.WriteString(nameof(UserDefinedNodeTypeNameOffset));
            emitter.WriteInt32(UserDefinedNodeTypeNameOffset);

            emitter.WriteString(nameof(NameHash));
            emitter.WriteUInt32(NameHash);

            emitter.WriteString(nameof(UnknownA));
            emitter.WriteUInt32(UnknownA);

            emitter.WriteString(nameof(NodeInfoOffset));
            emitter.WriteInt32(NodeInfoOffset);

            emitter.WriteString(nameof(ExbFunctionCount));
            emitter.WriteInt32(ExbFunctionCount);

            emitter.WriteString(nameof(ExbIOFieldSize));
            emitter.WriteInt32(ExbIOFieldSize);

            emitter.WriteString(nameof(MultiParameterCount));
            emitter.WriteInt32(MultiParameterCount);

            emitter.WriteString(nameof(UnknownB));
            emitter.WriteInt32(UnknownB);

            emitter.WriteString(nameof(BaseAttachmentParameterIndex));
            emitter.WriteInt32(BaseAttachmentParameterIndex);

            emitter.WriteString(nameof(BasePreconditionNode));
            emitter.WriteInt32(BasePreconditionNode);

            emitter.WriteString(nameof(PreconditionNodeCount));
            emitter.WriteInt32(PreconditionNodeCount);
        }
        emitter.EndMapping();
    }
}