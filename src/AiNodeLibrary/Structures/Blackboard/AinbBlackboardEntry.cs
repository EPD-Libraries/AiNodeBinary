namespace AiNodeLibrary.Structures.Blackboard;

public struct AinbBlackboardEntry
{
    /// <summary>
    /// Bit field containing the name offset and flags
    /// <para><c>[22]: Name Offset</c></para>
    /// <para><c>[1]</c></para>
    /// <para><c>[7]: File Reference Index</c></para>
    /// <para><c>[1]</c></para>
    /// </summary>
    public uint NameOffsetAndFlags;

    /// <summary>
    /// Notes
    /// </summary>
    public uint NotesOffset;
}
