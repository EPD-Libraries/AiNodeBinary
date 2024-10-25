using System.Runtime.InteropServices;
using VYaml.Emitter;

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

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.WriteString(nameof(Count));
        emitter.WriteInt32(Count);

        emitter.WriteString(nameof(Index));
        emitter.WriteInt32(Index);

        emitter.WriteString(nameof(Offset));
        emitter.WriteInt32(Offset);
    }
}
