using VYaml.Emitter;

namespace AinbLibrary.Structures;

public struct AinbCommand
{
    public int NameOffset;
    public Guid Id;
    public ushort LeftNodeIndex;

    /// <summary>
    /// One greater than the corresponding node index.
    /// </summary>
    public ushort RightNodeIndex;

    public readonly void EmitYaml(ref Utf8YamlEmitter emitter)
    {
        emitter.BeginMapping();
        {
            emitter.WriteString(nameof(NameOffset));
            emitter.WriteInt32(NameOffset);

            emitter.WriteString(nameof(Id));
            emitter.WriteString(Id.ToString());

            emitter.WriteString(nameof(LeftNodeIndex));
            emitter.WriteInt32(LeftNodeIndex);

            emitter.WriteString(nameof(RightNodeIndex));
            emitter.WriteInt32(RightNodeIndex);
        }
        emitter.EndMapping();
    }
}
