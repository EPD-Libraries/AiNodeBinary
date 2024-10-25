using System.Buffers;
using AinbLibrary.Legacy.Structures;
using VYaml.Emitter;

namespace AinbLibrary.Legacy.Yaml;

public static class AinbYamlEmitter
{
    public static void ToYaml(this ref AinbView ainb, in Stream output)
    {
        ArrayBufferWriter<byte> writer = new();
        Utf8YamlEmitter emitter = new(writer);

        emitter.BeginMapping();
        ainb.Header.EmitYaml(ref emitter);

        emitter.WriteString(nameof(ainb.Commands));
        emitter.BeginSequence();
        {
            foreach (AinbCommand command in ainb.Commands) {
                command.EmitYaml(ref emitter);
            }
        }
        emitter.EndSequence();

        emitter.WriteString(nameof(ainb.Nodes));
        emitter.BeginSequence();
        {
            foreach (AinbNode node in ainb.Nodes) {
                node.EmitYaml(ref emitter);
            }
        }
        emitter.EndSequence();

        ainb.BlackboardSection.EmitYaml(ref emitter);

        emitter.EndMapping();
        output.Write(writer.WrittenSpan);
    }
}
