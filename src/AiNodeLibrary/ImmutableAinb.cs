using AiNodeLibrary.Structures;
using Revrs;

namespace AiNodeLibrary;

public ref struct ImmutableAinb
{
    public AinbHeader Header;

    public ImmutableAinb(ref RevrsReader reader)
    {
        Header = reader.Read<AinbHeader>();
    }
}
