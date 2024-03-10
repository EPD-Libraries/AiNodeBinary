using System.Runtime.InteropServices;
using VYaml.Emitter;

namespace AinbLibrary.Structures.Blackboard;

[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0x10)]
public struct AinbBlackboardParametersFileReference
{
    public int FilePathOffset;
    public int FilePathHash;
    public int UnknownHashA;
    public int UnknownHashB;

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.BeginMapping();
        {
            emitter.WriteString(nameof(FilePathOffset));
            emitter.WriteInt32(FilePathOffset);

            emitter.WriteString(nameof(FilePathHash));
            emitter.WriteInt32(FilePathHash);

            emitter.WriteString(nameof(UnknownHashA));
            emitter.WriteInt32(UnknownHashA);

            emitter.WriteString(nameof(UnknownHashB));
            emitter.WriteInt32(UnknownHashB);
        }
        emitter.EndMapping();
    }
}
