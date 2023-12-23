using AiNodeLibrary;
using Revrs;
using System.Text;

byte[] data = File.ReadAllBytes(args[0]);
RevrsReader reader = new(data, Endianness.Little);
ImmutableAinb ainb = new(ref reader);

Console.WriteLine(
    $"Magic: {Encoding.UTF8.GetString(BitConverter.GetBytes(ainb.Header.Magic))}"
);

Console.WriteLine($"Version: {ainb.Header.Version:x2}");
Console.WriteLine($"File Name Offset: {ainb.Header.FileNameOffset}");
Console.WriteLine($"Command Count: {ainb.Header.CommandCount}");
Console.WriteLine($"Node Count: {ainb.Header.NodeCount}");
Console.WriteLine($"Precondition Node Count: {ainb.Header.PreconditionNodeCount}");
Console.WriteLine($"Attachment Parameter Count: {ainb.Header.AttachmentParameterCount}");
Console.WriteLine($"Output Node Count: {ainb.Header.OutputNodeCount}");
Console.WriteLine($"Local Blackboard Parameters Offset: {ainb.Header.LocalBlackboardParametersOffset}");
Console.WriteLine($"String Pool Offset: {ainb.Header.StringPoolOffset}");
Console.WriteLine($"Enum Resolve Array Offset: {ainb.Header.EnumResolveArrayOffset}");
Console.WriteLine($"Immediate Parameters Offset: {ainb.Header.ImmediateParametersOffset}");
Console.WriteLine($"Resident Update Array Offset: {ainb.Header.ResidentUpdateArrayOffset}");
Console.WriteLine($"Input/Ouput Parameters Offset: {ainb.Header.IOParametersOffset}");
Console.WriteLine($"Multi Parameters Array Offset: {ainb.Header.MultiParametersArrayOffset}");
Console.WriteLine($"Attachment Parameters Offset: {ainb.Header.AttachmentParametersOffset}");
Console.WriteLine($"Attachment Parameters Index Array Offset: {ainb.Header.AttachmentParametersIndexArrayOffset}");
Console.WriteLine($"Expression Binary Section Offset: {ainb.Header.ExbSectionOffset}");
Console.WriteLine($"Child Replacment Table Offset: {ainb.Header.ChildReplacmentTableOffset}");
Console.WriteLine($"Precondition Node Array Offset: {ainb.Header.PreconditionNodeArrayOffset}");
Console.WriteLine($"Unknown (A): {ainb.Header.UnknownA}");
Console.WriteLine($"Unknown (B): {ainb.Header.UnknownB}");
Console.WriteLine($"Unknown (C): {ainb.Header.UnknownC}");
Console.WriteLine($"Embedded Files Offset: {ainb.Header.EmbeddedFilesOffset}");
Console.WriteLine($"File Category Name Offset: {ainb.Header.FileCategoryNameOffset}");
Console.WriteLine($"File Category: {ainb.Header.FileCategory}");
Console.WriteLine($"Entry Strings Offset: {ainb.Header.EntryStringsOffset}");
Console.WriteLine($"Unknown (D): {ainb.Header.UnknownD}");
Console.WriteLine($"File Identification Hashes Offset: {ainb.Header.FileIdentificationHashesOffset}");

Console.WriteLine($"""


    Commands ({ainb.Header.CommandCount})
    - - - - - - - - - -

    """);

foreach (var command in ainb.Commands) {
    Console.WriteLine($"Command Name Offset: {command.NameOffset}");
    Console.WriteLine($"ID: {command.Id}");
    Console.WriteLine($"Left Index: {command.LeftNodeIndex}");
    Console.WriteLine($"Right Index: {command.RightNodeIndex}");
}

Console.WriteLine($"""


    Nodes ({ainb.Header.NodeCount})
    - - - - - - - - - -

    """);

foreach (var node in ainb.Nodes) {
    Console.WriteLine($"NodeType: {node.NodeType}");
    Console.WriteLine($"NodeIndex: {node.NodeIndex}");
    Console.WriteLine($"AttachmentParametersCount: {node.AttachmentParametersCount}");
    Console.WriteLine($"NodeFlags: {node.NodeFlags}");
    Console.WriteLine($"UserDefinedNodeTypeNameOffset: {node.UserDefinedNodeTypeNameOffset}");
    Console.WriteLine($"NameHash: {node.NameHash}");
    Console.WriteLine($"UnknownA: {node.UnknownA}");
    Console.WriteLine($"NodeBodyOffset: {node.NodeBodyOffset}");
    Console.WriteLine($"ExbFunctionCount: {node.ExbFunctionCount}");
    Console.WriteLine($"ExbIOFieldSize: {node.ExbIOFieldSize}");
    Console.WriteLine($"MultiParameterCount: {node.MultiParameterCount}");
    Console.WriteLine($"UnknownB: {node.UnknownB}");
    Console.WriteLine($"BaseAttachmentParameterIndex: {node.BaseAttachmentParameterIndex}");
    Console.WriteLine($"BasePreconditionNode: {node.BasePreconditionNode}");
    Console.WriteLine($"PreconditionNodeCount: {node.PreconditionNodeCount}");
    Console.WriteLine($"SectionEntryOffset: {node.SectionEntryOffset}");
    Console.WriteLine($"UnknownC: {node.UnknownC}");
    Console.WriteLine($"ID: {node.Id}\n");
}

Console.WriteLine($"""


    Local Blackboard
    - - - - - - - - - -

    """);

Console.WriteLine("Headers:");
foreach (var header in ainb.LocalBlackboard.Headers) {
    Console.WriteLine($"  Count: {header.Count}");
    Console.WriteLine($"  Index: {header.Index}");
    Console.WriteLine($"  Offset: {header.Offset}\n");
}

Console.WriteLine("Entries:");
foreach (var entry in ainb.LocalBlackboard.Entries) {
    Console.WriteLine($"  Name Offset and Flags: {entry.NameOffsetAndFlags:b8}");
    Console.WriteLine($"  Notes Offset: {entry.NotesOffset}\n");
}