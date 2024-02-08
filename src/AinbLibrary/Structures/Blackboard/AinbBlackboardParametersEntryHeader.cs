using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 2, Size = 8)]
public struct AinbBlackboardParametersEntryHeader
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
