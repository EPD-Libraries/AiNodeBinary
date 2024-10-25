namespace AinbLibrary.Blackboard;

public class AinbBlackboardProperty : IAinbBlackboardProperty
{
    public required string Name { get; set; }
    public string? Notes { get; set; }
    public IAinbBlackboardFileReference? FileReference { get; set; }
}
