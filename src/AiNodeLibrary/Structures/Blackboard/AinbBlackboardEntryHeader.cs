using System.Runtime.InteropServices;

namespace AiNodeLibrary.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct AinbBlackboardEntryHeader
{
    /// <summary>
    /// Number of Entries of the Corresponding Data Type
    /// </summary>
    public ushort Count;

    /// <summary>
    /// Parameter Index of the First Entry of the Corresponding Data Type
    /// </summary>
    public ushort Index;

    /// <summary>
    /// Relative Offset of the First Entry of the Corresponding Data Type
    /// </summary>
    public ushort Offset;
}
