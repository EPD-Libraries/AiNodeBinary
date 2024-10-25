namespace AinbLibrary.Blackboard;

public interface IAinbBlackboardProperty<T> : IAinbBlackboardProperty
{
    T DefaultValue { get; set; }
}