using AinbLibrary.Structures;

namespace AinbLibrary.Common;

public class AiCommand
{
    public required string Name { get; set; }
    public int LeftIndex { get; set; } = -1;
    public int RightIndex { get; set; } = -1;

    public Guid Id { get; set; } = Guid.Empty;

    public static AiCommand FromCommandView(AinbView ainb, AinbCommand command)
    {
        return new AiCommand {
            Name = ainb.GetString(command.NameOffset),
            LeftIndex = command.LeftNodeIndex,
            RightIndex = command.RightNodeIndex,
            Id = command.Id
        };
    }
}
