namespace AinbLibrary.Connections;

public abstract class AinbConnection : IAinbConnection
{
    public int Index { get; set; } = -1;
}
