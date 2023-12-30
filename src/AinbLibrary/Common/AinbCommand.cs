namespace AinbLibrary.Common;

public class AinbCommand(string name)
{
    public string Name { get; set; } = name;
    public int LeftIndex { get; set; } = -1;
    public int RightIndex { get; set; } = -1;

    public Guid DebugId { get; set; } = Guid.Empty;
}
