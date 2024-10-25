using AinbLibrary.Blackboard;

namespace AinbLibrary;

public interface IAinb
{
    string Name { get; set; }
    AinbVersion Version { get; set; }
    IAinbBlackboard Blackboard { get; set; }
    IList<IAinbCommand> Commands { get; set; }
    IList<IAinbNode> Nodes { get; set; }
}
