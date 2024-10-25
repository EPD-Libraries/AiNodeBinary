using System.Runtime.InteropServices;
using VYaml.Emitter;

namespace AinbLibrary.Legacy.Structures;

public enum AiNodeType : ushort
{
    /// <summary>
    /// Custom node type, definition in NodeDefinition.
    /// </summary>
    UserDefined = 0,

    /// <summary>
    /// Conditionally links to a node depending on the value of a signed int.
    /// </summary>
    ElementS32Selector = 1,

    /// <summary>
    /// Links to nodes sequentially in the order listed.
    /// </summary>
    ElementSequential = 2,

    /// <summary>
    /// Links simultaneously to multiple nodes.
    /// </summary>
    ElementSimultaneous = 3,

    /// <summary>
    /// Conditionally links to a node depending on the value of 32-bit float.
    /// </summary>
    ElementF32Selector = 4,

    /// <summary>
    /// Conditionally links to a node depending on the value of a string.
    /// </summary>
    ElementStringSelector = 5,

    /// <summary>
    /// Links to a node randomly.
    /// </summary>
    ElementRandomSelector = 6,

    /// <summary>
    /// Conditionally links to a node depending on the value of a bool.
    /// </summary>
    ElementBoolSelector = 7,

    /// <summary>
    /// See Resident Update Array.
    /// </summary>
    ElementFork = 8,

    /// <summary>
    /// See Resident Update Array.
    /// </summary>
    ElementJoin = 9,

    /// <summary>
    /// Displays a debug message.
    /// </summary>
    ElementAlert = 10,

    /// <summary>
    /// Passes values to and from EXB commands.
    /// </summary>
    ElementExpression = 20,

    /// <summary>
    /// Passes a signed int as output to another node as input.
    /// </summary>
    ElementModuleIfInputS32 = 100,

    /// <summary>
    /// Passes a 32-bit float as output to another node as input.
    /// </summary>
    ElementModuleIfInputF32 = 101,

    /// <summary>
    /// Passes a vector3f as output to another node as input.
    /// </summary>
    ElementModuleIfInputVec3F = 102,

    /// <summary>
    /// Passes a string as output to another node as input.
    /// </summary>
    ElementModuleIfInputString = 103,

    /// <summary>
    /// Passes a boolean int as output to another node as input.
    /// </summary>
    ElementModuleIfInputBool = 104,

    /// <summary>
    /// Passes a pointer as output to another node as input.
    /// </summary>
    ElementModuleIfInputPtr = 105,

    /// <summary>
    /// Passes a signed int as output to another node as output.
    /// </summary>
    ElementModuleIfOutputS32 = 200,

    /// <summary>
    /// Passes a 32-bit float as output to another node as output.
    /// </summary>
    ElementModuleIfOutputF32 = 201,

    /// <summary>
    /// Passes a vector3f as output to another node as output.
    /// </summary>
    ElementModuleIfOutputVec3F = 202,

    /// <summary>
    /// Passes a string as output to another node as output.
    /// </summary>
    ElementModuleIfOutputString = 203,

    /// <summary>
    /// Passes a boolean int as output to another node as output.
    /// </summary>
    ElementModuleIfOutputBool = 204,

    /// <summary>
    /// Passes a pointer as output to another node as output.
    /// </summary>
    ElementModuleIfOutputPtr = 205,

    /// <summary>
    /// Unsure, appears to just be a node connected to a ModuleIF node as a child node.
    /// </summary>
    ElementModuleIfChild = 300,

    /// <summary>
    /// Termination node.
    /// </summary>
    ElementStateEnd = 400,

    /// <summary>
    /// Changes when child nodes are run (Enter - first time visiting a node, Update - every frame, Leave - ran upon leaving the node).
    /// </summary>
    ElementSplitTiming = 500,
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