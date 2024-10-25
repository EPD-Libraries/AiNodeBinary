namespace AinbLibrary.IO.Structures;

public struct AinbCommandHeader
{
    public int NameOffset;
    public Guid Id;
    public ushort LeftNodeIndex;

    /// <summary>
    /// One greater than the corresponding node index.
    /// </summary>
    public ushort RightNodeIndex;
}
