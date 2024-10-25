using System.Numerics;

namespace AinbLibrary.Blackboard;

public class AinbBlackboard : IAinbBlackboard
{
    public IList<IAinbBlackboardProperty<string>> StringProperties { get; set; } = [];
    public IList<IAinbBlackboardProperty<int>> IntProperties { get; set; } = [];
    public IList<IAinbBlackboardProperty<float>> FloatProperties { get; set; } = [];
    public IList<IAinbBlackboardProperty<bool>> BoolProperties { get; set; } = [];
    public IList<IAinbBlackboardProperty<Vector3>> VectorProperties { get; set; } = [];
    public IList<IAinbBlackboardProperty> PointerProperties { get; set; } = [];
}
