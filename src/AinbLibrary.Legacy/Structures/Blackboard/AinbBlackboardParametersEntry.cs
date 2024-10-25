using System.Runtime.InteropServices;
using VYaml.Emitter;

namespace AinbLibrary.Legacy.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct AinbBlackboardParametersEntry
{
    public NameOffsetAndFlagsBitfield NameOffsetAndFlags;

    /// <summary>
    /// Notes
    /// </summary>
    public int NotesOffset;

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 4, Size = 4)]
    public readonly struct NameOffsetAndFlagsBitfield
    {
        [FieldOffset(0)]
        public readonly int Value;

        public readonly int NameOffset {
            get => Value & 0x3FFFFF;
        }

        public readonly int HasFileReference {
            // If the bit is set, return 0 (false)
            // otherwise return 1 (true)
            get => ((Value >> 23) & 0b1) ^ 1;
        }

        public readonly int FileReferenceIndex {
            get => (Value >> 24) & 0x7F;
        }

        public readonly int IsValidFileReference {
            get => Value >> 31;
        }
    }

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.BeginMapping();
        {
            emitter.WriteString(nameof(NameOffsetAndFlags.NameOffset));
            emitter.WriteInt32(NameOffsetAndFlags.NameOffset);

            emitter.WriteString(nameof(NameOffsetAndFlags.HasFileReference));
            emitter.WriteInt32(NameOffsetAndFlags.HasFileReference);

            emitter.WriteString(nameof(NameOffsetAndFlags.FileReferenceIndex));
            emitter.WriteInt32(NameOffsetAndFlags.FileReferenceIndex);

            emitter.WriteString(nameof(NameOffsetAndFlags.IsValidFileReference));
            emitter.WriteInt32(NameOffsetAndFlags.IsValidFileReference);

            emitter.WriteString(nameof(NotesOffset));
            emitter.WriteInt32(NotesOffset);
        }
        emitter.EndMapping();
    }
}
