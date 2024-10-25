namespace AinbLibrary.IO.Structures.Blackboard;

public struct AinbBlackboardEntriesHeader
{
    /// <summary>
    /// Number of entries of the corresponding data type
    /// </summary>
    public ushort Count;

    /// <summary>
    /// Parameter index of the First Entry of the corresponding data type
    /// </summary>
    public ushort Index;

    /// <summary>
    /// Relative offset of the First Entry of the corresponding data type
    /// </summary>
    public ushort Offset;
}
