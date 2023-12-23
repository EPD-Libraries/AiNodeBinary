namespace AiNodeLibrary.Structures;

public struct AinbCommand
{
    public int NameOffset;
    public Guid Id;
    public ushort LeftNodeIndex;

    /// <summary>
    /// One greater than the corresponding node index.
    /// </summary>
    public ushort RightNodeIndex;
}
