namespace AinbLibrary.Blackboard;

public interface IAinbBlackboardProperty
{
    string Name { get; set; }
    string? Notes { get; set; }
    IAinbBlackboardFileReference? FileReference { get; set; }
}
