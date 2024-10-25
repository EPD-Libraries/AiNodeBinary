using System.Numerics;

namespace AinbLibrary.Blackboard;

public interface IAinbBlackboard
{
    IList<IAinbBlackboardProperty<string>> StringProperties { get; set; }
    IList<IAinbBlackboardProperty<int>> IntProperties { get; set; }
    IList<IAinbBlackboardProperty<float>> FloatProperties { get; set; }
    IList<IAinbBlackboardProperty<bool>> BoolProperties { get; set; }
    IList<IAinbBlackboardProperty<Vector3>> VectorProperties { get; set; }
    IList<IAinbBlackboardProperty> PointerProperties { get; set; }
}
