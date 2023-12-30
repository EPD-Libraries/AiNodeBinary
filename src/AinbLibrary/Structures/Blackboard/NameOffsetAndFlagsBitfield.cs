using System.Runtime.InteropServices;

namespace AinbLibrary.Structures.Blackboard;

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 4, Size = 4)]
public readonly struct NameOffsetAndFlagsBitfield
{
    [FieldOffset(0)]
    public readonly int Value;

    public readonly int NameOffset {
        get => Value & 0x3FFFFF;
    }

    public readonly bool HasFileReference {
        get => ((Value >> 23) & 0b1) == 0x0;
    }

    public readonly int FileReferenceIndex {
        get => (Value >> 24) & 0x7F;
    }

    public readonly bool IsValidFileReference {
        get => (Value >> 31) == 1;
    }
}
