using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AinbLibrary.IO.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct AinbBlackboardEntry
{
    private readonly int _nameAndFlags;

    public readonly int NameOffset {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _nameAndFlags & 0x3FFFFF;
    }

    public readonly int HasFileReference {
        // If the bit is set, return 0 (false)
        // otherwise return 1 (true)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ((_nameAndFlags >> 23) & 0b1) ^ 1;
    }

    public readonly int FileReferenceIndex {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (_nameAndFlags >> 24) & 0x7F;
    }

    public readonly int IsValidFileReference {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _nameAndFlags >> 31;
    }

    public int NotesOffset;
}
