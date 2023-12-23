using AiNodeLibrary;
using Revrs;
using System.Text;

byte[] data = File.ReadAllBytes(args[0]);
RevrsReader reader = new(data, Endianness.Little);
ImmutableAinb ainb = new(ref reader);

Console.WriteLine(
    $"Magic: {Encoding.UTF8.GetString(BitConverter.GetBytes(ainb.Header.Magic))}"
);

Console.WriteLine($"Version: {ainb.Header.Version}");
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
Console.WriteLine($"Expression Binary Section Offset: {ainb.Header.ExpressionBinarySectionOffset}");
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