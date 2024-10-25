using AinbLibrary.Connections;

namespace AinbLibrary;

public enum AinbNodeType : ushort
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
    /// Passes a vector3 as output to another node as input.
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
    /// Passes a vector3 as output to another node as output.
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
public enum AinbNodeFlags : byte
{
    None = 0,
    IsPreconditionNode = 1,
    IsExternalFile = 2,
    IsResidentNode = 4
}

public interface IAinbNode
{
    AinbNodeType Type { get; set; }
    AinbNodeFlags Flags { get; set; }
    string? CustomTypeName { get; set; }
    IList<IAinbConnection> Connections { get; set; }
    Guid Id { get; set; }
}
