using AinbLibrary.IO.Extensions;
using AinbLibrary.IO.Structures;
using Revrs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace AinbLibrary.IO;

public ref struct AinbReader
{
    public const uint MAGIC = 0x20424941;

    private readonly Span<byte> _buffer;

    public AinbHeader Header;
    public Span<AinbCommandHeader> Commands;
    public Span<AinbNodeHeader> Nodes;
    public AinbBlackboardReader BlackboardReader;
    public AinbAttachmentReader AttachmentReader;
    public Span<byte> StringPool;

    public AinbReader(ref RevrsReader reader)
    {
        Header = reader.Read<AinbHeader>();

        if (Header.Magic != MAGIC) {
            throw new InvalidDataException(
                $"Invalid magic: expected 'AIB ' but found '{Header.Magic.GetString()}'");
        }

        if (Header.Version is not { Major: 7, Minor: 4 } or { Major: 4, Minor: 4 }) {
            throw new InvalidDataException(
                $"Unsupported version: '{Header.Version}' expected '7.4.x' or '4.4.x'");
        }

        Commands = reader.ReadSpan<AinbCommandHeader>(Header.CommandCount);
        Nodes = reader.ReadSpan<AinbNodeHeader>(Header.NodeCount);
        BlackboardReader = new AinbBlackboardReader(ref reader);
        AttachmentReader = new AinbAttachmentReader(ref reader, Header.AttachmentParameterCount);
        StringPool = reader.ReadSpan<byte>(reader.Length - Header.StringPoolOffset, Header.StringPoolOffset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly AinbNodeContentReader GetNodeContentReader(AinbNodeHeader node)
    {
        return new AinbNodeContentReader(_buffer[node.NodeContentOffset..]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly unsafe string ReadString(int offset)
    {
        fixed (byte* ptr = StringPool[offset..]) {
            return Utf8StringMarshaller.ConvertToManaged(ptr)
                ?? string.Empty;
        }
    }
}
