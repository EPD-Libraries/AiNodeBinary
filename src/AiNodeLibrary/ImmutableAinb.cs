using AiNodeLibrary.Structures;
using Revrs;

namespace AiNodeLibrary;

public ref struct ImmutableAinb
{
    public AinbHeader Header;

    public ImmutableAinb(ref RevrsReader reader)
    {
        Header = reader.Read<AinbHeader>();

        if (Header.Magic != AinbHeader.AINB_MAGIC) {
            throw new InvalidDataException("Invalid AINB magic!");
        }

        if (Header.Version is not 0x407 or 0x404) {
            throw new InvalidDataException($"Unsupported version: {Header.Version:x2}");
        }
    }
}
