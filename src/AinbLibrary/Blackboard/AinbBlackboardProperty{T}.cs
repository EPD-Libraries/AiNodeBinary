namespace AinbLibrary.Blackboard;

public class AinbBlackboardProperty<T> : AinbBlackboardProperty, IAinbBlackboardProperty<T>
{
    public required T DefaultValue { get; set; }
}
