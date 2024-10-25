namespace AinbLibrary.Blackboard;

public class AinbBlackboardFileReference : IAinbBlackboardFileReference
{
    public required string Name { get; set; }
    public uint UnknownHash1 { get; set; }
    public uint UnknownHash2 { get; set; }
}
