using AinbLibrary;
using Revrs;
using System.Text;

byte[] data = File.ReadAllBytes(args[0]);
RevrsReader reader = new(data, Endianness.Little);
ImmutableAinb ainb = new(ref reader);

StringBuilder sb = new();

sb.AppendLine(
    $"Magic: '{Encoding.UTF8.GetString(BitConverter.GetBytes(ainb.Header.Magic))}'"
);

sb.AppendLine($"Version: {ainb.Header.Version:x2}");
sb.AppendLine($"File Name Offset: {ainb.Header.FileNameOffset}");
sb.AppendLine($"Command Count: {ainb.Header.CommandCount}");
sb.AppendLine($"Node Count: {ainb.Header.NodeCount}");
sb.AppendLine($"Precondition Node Count: {ainb.Header.PreconditionNodeCount}");
sb.AppendLine($"Attachment Parameter Count: {ainb.Header.AttachmentParameterCount}");
sb.AppendLine($"Output Node Count: {ainb.Header.OutputNodeCount}");
sb.AppendLine($"Local Blackboard Parameters Offset: {ainb.Header.LocalBlackboardParametersOffset}");
sb.AppendLine($"String Pool Offset: {ainb.Header.StringPoolOffset}");
sb.AppendLine($"Enum Resolve Array Offset: {ainb.Header.EnumResolveArrayOffset}");
sb.AppendLine($"Immediate Parameters Offset: {ainb.Header.ImmediateParametersOffset}");
sb.AppendLine($"Resident Update Array Offset: {ainb.Header.ResidentUpdateArrayOffset}");
sb.AppendLine($"Input/Ouput Parameters Offset: {ainb.Header.IOParametersOffset}");
sb.AppendLine($"Multi Parameters Array Offset: {ainb.Header.MultiParametersArrayOffset}");
sb.AppendLine($"Attachment Parameters Offset: {ainb.Header.AttachmentParametersOffset}");
sb.AppendLine($"Attachment Parameters Index Array Offset: {ainb.Header.AttachmentParametersIndexArrayOffset}");
sb.AppendLine($"Expression Binary Section Offset: {ainb.Header.ExbSectionOffset}");
sb.AppendLine($"Child Replacment Table Offset: {ainb.Header.ChildReplacmentTableOffset}");
sb.AppendLine($"Precondition Node Array Offset: {ainb.Header.PreconditionNodeArrayOffset}");
sb.AppendLine($"Unknown (A): {ainb.Header.UnknownA}");
sb.AppendLine($"Unknown (B): {ainb.Header.UnknownB}");
sb.AppendLine($"Unknown (C): {ainb.Header.UnknownC}");
sb.AppendLine($"Embedded Files Offset: {ainb.Header.EmbeddedFilesOffset}");
sb.AppendLine($"File Category Name Offset: {ainb.Header.FileCategoryNameOffset}");
sb.AppendLine($"File Category: {ainb.Header.FileCategory}");
sb.AppendLine($"Entry Strings Offset: {ainb.Header.EntryStringsOffset}");
sb.AppendLine($"Unknown (D): {ainb.Header.UnknownD}");
sb.AppendLine($"File Identification Hashes Offset: {ainb.Header.FileIdentificationHashesOffset}");

sb.AppendLine($"""

    # Commands ({ainb.Header.CommandCount})
    # - - - - - - - - - -

    Commands:
    """);

foreach (var command in ainb.Commands) {
    sb.AppendLine($"- Command Name Offset: {command.NameOffset}");
    sb.AppendLine($"  ID: {command.Id}");
    sb.AppendLine($"  Left Index: {command.LeftNodeIndex}");
    sb.AppendLine($"  Right Index: {command.RightNodeIndex}");
}

sb.AppendLine($"""

    # Nodes ({ainb.Header.NodeCount})
    # - - - - - - - - - -

    Nodes:
    """);

foreach (var node in ainb.Nodes) {
    sb.AppendLine($"- NodeType: {node.NodeType}");
    sb.AppendLine($"  NodeIndex: {node.NodeIndex}");
    sb.AppendLine($"  AttachmentParametersCount: {node.AttachmentParameterCount}");
    sb.AppendLine($"  NodeFlags: {node.NodeFlags}");
    sb.AppendLine($"  UserDefinedNodeTypeNameOffset: {node.UserDefinedNodeTypeNameOffset}");
    sb.AppendLine($"  NameHash: {node.NameHash}");
    sb.AppendLine($"  UnknownA: {node.UnknownA}");
    sb.AppendLine($"  NodeBodyOffset: {node.NodeBodyOffset}");
    sb.AppendLine($"  ExbFunctionCount: {node.ExbFunctionCount}");
    sb.AppendLine($"  ExbIOFieldSize: {node.ExbIOFieldSize}");
    sb.AppendLine($"  MultiParameterCount: {node.MultiParameterCount}");
    sb.AppendLine($"  UnknownB: {node.UnknownB}");
    sb.AppendLine($"  BaseAttachmentParameterIndex: {node.BaseAttachmentParameterIndex}");
    sb.AppendLine($"  BasePreconditionNode: {node.BasePreconditionNode}");
    sb.AppendLine($"  PreconditionNodeCount: {node.PreconditionNodeCount}");
    sb.AppendLine($"  SectionEntryOffset: {node.SectionEntryOffset}");
    sb.AppendLine($"  UnknownC: {node.UnknownC}");
    sb.AppendLine($"  ID: {node.Id}");
}

sb.AppendLine($"""

    # Local Blackboard
    # - - - - - - - - - -

    LocalBlackboard:
    """);

sb.AppendLine("  String:");
sb.AppendLine($"    Header.Count: {ainb.LocalBlackboardSection.StringHeader.Count}");
sb.AppendLine($"    Header.Offset: {ainb.LocalBlackboardSection.StringHeader.Offset}");
sb.AppendLine($"    Header.Index: {ainb.LocalBlackboardSection.StringHeader.Index}");

sb.AppendLine("    Entries:");
foreach (var entry in ainb.LocalBlackboardSection.StringEntries) {
    sb.AppendLine($"    - Entry.Flags.NameOffset: {entry.NameOffsetAndFlags.NameOffset}");
    sb.AppendLine($"      Entry.Flags.HasFileReference: {entry.NameOffsetAndFlags.HasFileReference}");
    sb.AppendLine($"      Entry.Flags.FileReferenceIndex: {entry.NameOffsetAndFlags.FileReferenceIndex}");
    sb.AppendLine($"      Entry.Flags.IsValidFileReference: {entry.NameOffsetAndFlags.IsValidFileReference}");
    sb.AppendLine($"      Entry.NotesOffset: {entry.NotesOffset}");
}

sb.AppendLine("    Values:");
foreach (var value in ainb.LocalBlackboardSection.StringDefaultValues) {
    sb.AppendLine($"    - Value: {value}");
}

sb.AppendLine("  Int:");
sb.AppendLine($"    Header.Count: {ainb.LocalBlackboardSection.IntHeader.Count}");
sb.AppendLine($"    Header.Offset: {ainb.LocalBlackboardSection.IntHeader.Offset}");
sb.AppendLine($"    Header.Index: {ainb.LocalBlackboardSection.IntHeader.Index}");

sb.AppendLine("    Entries:");
foreach (var entry in ainb.LocalBlackboardSection.IntEntries) {
    sb.AppendLine($"    - Entry.Flags.NameOffset: {entry.NameOffsetAndFlags.NameOffset}");
    sb.AppendLine($"      Entry.Flags.HasFileReference: {entry.NameOffsetAndFlags.HasFileReference}");
    sb.AppendLine($"      Entry.Flags.FileReferenceIndex: {entry.NameOffsetAndFlags.FileReferenceIndex}");
    sb.AppendLine($"      Entry.Flags.IsValidFileReference: {entry.NameOffsetAndFlags.IsValidFileReference}");
    sb.AppendLine($"      Entry.NotesOffset: {entry.NotesOffset}");
}

sb.AppendLine("    Values:");
foreach (var value in ainb.LocalBlackboardSection.IntDefaultValues) {
    sb.AppendLine($"    - Value: {value}");
}

sb.AppendLine("  Float:");
sb.AppendLine($"    Header.Count: {ainb.LocalBlackboardSection.FloatHeader.Count}");
sb.AppendLine($"    Header.Offset: {ainb.LocalBlackboardSection.FloatHeader.Offset}");
sb.AppendLine($"    Header.Index: {ainb.LocalBlackboardSection.FloatHeader.Index}");

sb.AppendLine("    Entries:");
foreach (var entry in ainb.LocalBlackboardSection.FloatEntries) {
    sb.AppendLine($"    - Entry.Flags.NameOffset: {entry.NameOffsetAndFlags.NameOffset}");
    sb.AppendLine($"      Entry.Flags.HasFileReference: {entry.NameOffsetAndFlags.HasFileReference}");
    sb.AppendLine($"      Entry.Flags.FileReferenceIndex: {entry.NameOffsetAndFlags.FileReferenceIndex}");
    sb.AppendLine($"      Entry.Flags.IsValidFileReference: {entry.NameOffsetAndFlags.IsValidFileReference}");
    sb.AppendLine($"      Entry.NotesOffset: {entry.NotesOffset}");
}

sb.AppendLine("    Values:");
foreach (var value in ainb.LocalBlackboardSection.FloatDefaultValues) {
    sb.AppendLine($"    - Value: {value}");
}

sb.AppendLine("  Bool:");
sb.AppendLine($"    Header.Count: {ainb.LocalBlackboardSection.BoolHeader.Count}");
sb.AppendLine($"    Header.Offset: {ainb.LocalBlackboardSection.BoolHeader.Offset}");
sb.AppendLine($"    Header.Index: {ainb.LocalBlackboardSection.BoolHeader.Index}");

sb.AppendLine("    Entries:");
foreach (var entry in ainb.LocalBlackboardSection.BoolEntries) {
    sb.AppendLine($"    - Entry.Flags.NameOffset: {entry.NameOffsetAndFlags.NameOffset}");
    sb.AppendLine($"      Entry.Flags.HasFileReference: {entry.NameOffsetAndFlags.HasFileReference}");
    sb.AppendLine($"      Entry.Flags.FileReferenceIndex: {entry.NameOffsetAndFlags.FileReferenceIndex}");
    sb.AppendLine($"      Entry.Flags.IsValidFileReference: {entry.NameOffsetAndFlags.IsValidFileReference}");
    sb.AppendLine($"      Entry.NotesOffset: {entry.NotesOffset}");
}

sb.AppendLine("    Values:");
foreach (var value in ainb.LocalBlackboardSection.BoolDefaultValues) {
    sb.AppendLine($"    - Value: {value}");
}

sb.AppendLine("  Vector:");
sb.AppendLine($"    Header.Count: {ainb.LocalBlackboardSection.VectorHeader.Count}");
sb.AppendLine($"    Header.Offset: {ainb.LocalBlackboardSection.VectorHeader.Offset}");
sb.AppendLine($"    Header.Index: {ainb.LocalBlackboardSection.VectorHeader.Index}");

sb.AppendLine("    Entries:");
foreach (var entry in ainb.LocalBlackboardSection.VectorEntries) {
    sb.AppendLine($"    - Entry.Flags.NameOffset: {entry.NameOffsetAndFlags.NameOffset}");
    sb.AppendLine($"      Entry.Flags.HasFileReference: {entry.NameOffsetAndFlags.HasFileReference}");
    sb.AppendLine($"      Entry.Flags.FileReferenceIndex: {entry.NameOffsetAndFlags.FileReferenceIndex}");
    sb.AppendLine($"      Entry.Flags.IsValidFileReference: {entry.NameOffsetAndFlags.IsValidFileReference}");
    sb.AppendLine($"      Entry.NotesOffset: {entry.NotesOffset}");
}

sb.AppendLine("    Values:");
foreach (var value in ainb.LocalBlackboardSection.VectorDefaultValues) {
    sb.AppendLine($"    - Value: {value}");
}

sb.AppendLine("  Pointer:");
sb.AppendLine($"    Header.Count: {ainb.LocalBlackboardSection.PointerHeader.Count}");
sb.AppendLine($"    Header.Offset: {ainb.LocalBlackboardSection.PointerHeader.Offset}");
sb.AppendLine($"    Header.Index: {ainb.LocalBlackboardSection.PointerHeader.Index}");

sb.AppendLine("    Entries:");
foreach (var entry in ainb.LocalBlackboardSection.PointerEntries) {
    sb.AppendLine($"    - Entry.Flags.NameOffset: {entry.NameOffsetAndFlags.NameOffset}");
    sb.AppendLine($"      Entry.Flags.HasFileReference: {entry.NameOffsetAndFlags.HasFileReference}");
    sb.AppendLine($"      Entry.Flags.FileReferenceIndex: {entry.NameOffsetAndFlags.FileReferenceIndex}");
    sb.AppendLine($"      Entry.Flags.IsValidFileReference: {entry.NameOffsetAndFlags.IsValidFileReference}");
    sb.AppendLine($"      Entry.NotesOffset: {entry.NotesOffset}");
}

sb.AppendLine("  All File References:");
foreach (var reference in ainb.LocalBlackboardSection.FileReferences) {
    sb.AppendLine($"  - Reference.FilePathHash: {reference.FilePathHash}");
    sb.AppendLine($"    Referemce.FilePathOffset: {reference.FilePathOffset}");
    sb.AppendLine($"    Referemce.UnknownHashA: {reference.UnknownHashA}");
    sb.AppendLine($"    Referemce.UnknownHashB: {reference.UnknownHashB}");
}

sb.AppendLine($"""

    # Node Bodies
    # - - - - - - - - - -

    NodeBodies:
    """);

// sb.AppendLine($"- Parameter Header:");
// sb.AppendLine($"    IntImmediateParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.IntImmediateParameterBaseIndex}");
// sb.AppendLine($"    IntImmediateParameterCount: {ainb.NodeBodySection.ParameterHeader.IntImmediateParameterCount}");
// sb.AppendLine($"    BoolImmediateParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.BoolImmediateParameterBaseIndex}");
// sb.AppendLine($"    BoolImmediateParameterCount: {ainb.NodeBodySection.ParameterHeader.BoolImmediateParameterCount}");
// sb.AppendLine($"    FloatImmediateParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.FloatImmediateParameterBaseIndex}");
// sb.AppendLine($"    FloatImmediateParameterCount: {ainb.NodeBodySection.ParameterHeader.FloatImmediateParameterCount}");
// sb.AppendLine($"    StringImmediateParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.StringImmediateParameterBaseIndex}");
// sb.AppendLine($"    StringImmediateParameterCount: {ainb.NodeBodySection.ParameterHeader.StringImmediateParameterCount}");
// sb.AppendLine($"    Vector3fImmediateParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.Vector3fImmediateParameterBaseIndex}");
// sb.AppendLine($"    Vector3fImmediateParameterCount: {ainb.NodeBodySection.ParameterHeader.Vector3fImmediateParameterCount}");
// sb.AppendLine($"    PointerImmediateParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.PointerImmediateParameterBaseIndex}");
// sb.AppendLine($"    PointerImmediateParameterCount: {ainb.NodeBodySection.ParameterHeader.PointerImmediateParameterCount}");
// sb.AppendLine($"    IntInputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.IntInputParameterBaseIndex}");
// sb.AppendLine($"    IntInputParameterCount: {ainb.NodeBodySection.ParameterHeader.IntInputParameterCount}");
// sb.AppendLine($"    IntOutputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.IntOutputParameterBaseIndex}");
// sb.AppendLine($"    IntOutputParameterCount: {ainb.NodeBodySection.ParameterHeader.IntOutputParameterCount}");
// sb.AppendLine($"    BoolInputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.BoolInputParameterBaseIndex}");
// sb.AppendLine($"    BoolInputParameterCount: {ainb.NodeBodySection.ParameterHeader.BoolInputParameterCount}");
// sb.AppendLine($"    BoolOutputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.BoolOutputParameterBaseIndex}");
// sb.AppendLine($"    BoolOutputParameterCount: {ainb.NodeBodySection.ParameterHeader.BoolOutputParameterCount}");
// sb.AppendLine($"    FloatInputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.FloatInputParameterBaseIndex}");
// sb.AppendLine($"    FloatInputParameterCount: {ainb.NodeBodySection.ParameterHeader.FloatInputParameterCount}");
// sb.AppendLine($"    FloatOutputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.FloatOutputParameterBaseIndex}");
// sb.AppendLine($"    FloatOutputParameterCount: {ainb.NodeBodySection.ParameterHeader.FloatOutputParameterCount}");
// sb.AppendLine($"    StringInputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.StringInputParameterBaseIndex}");
// sb.AppendLine($"    StringInputParameterCount: {ainb.NodeBodySection.ParameterHeader.StringInputParameterCount}");
// sb.AppendLine($"    StringOutputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.StringOutputParameterBaseIndex}");
// sb.AppendLine($"    StringOutputParameterCount: {ainb.NodeBodySection.ParameterHeader.StringOutputParameterCount}");
// sb.AppendLine($"    Vector3fInputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.Vector3fInputParameterBaseIndex}");
// sb.AppendLine($"    Vector3fInputParameterCount: {ainb.NodeBodySection.ParameterHeader.Vector3fInputParameterCount}");
// sb.AppendLine($"    Vector3fOutputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.Vector3fOutputParameterBaseIndex}");
// sb.AppendLine($"    Vector3fOutputParameterCount: {ainb.NodeBodySection.ParameterHeader.Vector3fOutputParameterCount}");
// sb.AppendLine($"    PointerInputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.PointerInputParameterBaseIndex}");
// sb.AppendLine($"    PointerInputParameterCount: {ainb.NodeBodySection.ParameterHeader.PointerInputParameterCount}");
// sb.AppendLine($"    PointerOutputParameterBaseIndex: {ainb.NodeBodySection.ParameterHeader.PointerOutputParameterBaseIndex}");
// sb.AppendLine($"    PointerOutputParameterCount: {ainb.NodeBodySection.ParameterHeader.PointerOutputParameterCount}");
   
// sb.AppendLine($"  Child Node Header:");
// sb.AppendLine($"    BoolInputFloatOutputSourceNodeCount: {ainb.NodeBodySection.ChildNodeHeader.BoolInputFloatOutputSourceNodeCount}");
// sb.AppendLine($"    BoolInputFloatOutputSourceNodeBaseIndex: {ainb.NodeBodySection.ChildNodeHeader.BoolInputFloatOutputSourceNodeBaseIndex}");
// sb.AppendLine($"    UnknownConnectionTypeCount_1: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeCount_1}");
// sb.AppendLine($"    UnknownConnectionTypeBaseIndex_1: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeBaseIndex_1}");
// sb.AppendLine($"    StandardChildNodeCount: {ainb.NodeBodySection.ChildNodeHeader.StandardChildNodeCount}");
// sb.AppendLine($"    StandardChildNodeBaseIndex: {ainb.NodeBodySection.ChildNodeHeader.StandardChildNodeBaseIndex}");
// sb.AppendLine($"    ResidentUpdateNodeCount: {ainb.NodeBodySection.ChildNodeHeader.ResidentUpdateNodeCount}");
// sb.AppendLine($"    ResidentUpdateBaseIndex: {ainb.NodeBodySection.ChildNodeHeader.ResidentUpdateBaseIndex}");
// sb.AppendLine($"    StringInputSourceNodeCount: {ainb.NodeBodySection.ChildNodeHeader.StringInputSourceNodeCount}");
// sb.AppendLine($"    StringInputSourceNodeBaseIndex: {ainb.NodeBodySection.ChildNodeHeader.StringInputSourceNodeBaseIndex}");
// sb.AppendLine($"    IntInputSourceNodeCount: {ainb.NodeBodySection.ChildNodeHeader.IntInputSourceNodeCount}");
// sb.AppendLine($"    IntInputSourceNodeBaseIndex: {ainb.NodeBodySection.ChildNodeHeader.IntInputSourceNodeBaseIndex}");
// sb.AppendLine($"    UnknownConnectionTypeCount_2: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeCount_2}");
// sb.AppendLine($"    UnknownConnectionTypeBaseIndex_2: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeBaseIndex_2}");
// sb.AppendLine($"    UnknownConnectionTypeCount_3: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeCount_3}");
// sb.AppendLine($"    UnknownConnectionTypeBaseIndex_3: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeBaseIndex_3}");
// sb.AppendLine($"    UnknownConnectionTypeCount_4: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeCount_4}");
// sb.AppendLine($"    UnknownConnectionTypeBaseIndex_4: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeBaseIndex_4}");
// sb.AppendLine($"    UnknownConnectionTypeCount_5: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeCount_5}");
// sb.AppendLine($"    UnknownConnectionTypeBaseIndex_5: {ainb.NodeBodySection.ChildNodeHeader.UnknownConnectionTypeBaseIndex_5}");

File.WriteAllText("D:\\Bin\\AINB\\output.yml", sb.ToString());