using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct AinbBlackboardEntry
{
    public NameOffsetAndFlagsBitfield NameOffsetAndFlags;

    /// <summary>
    /// Notes
    /// </summary>
    public uint NotesOffset;
}
