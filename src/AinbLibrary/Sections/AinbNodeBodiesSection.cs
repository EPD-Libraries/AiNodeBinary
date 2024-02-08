using AinbLibrary.Structures.NodeBodies;
using Revrs;

namespace AinbLibrary.Sections;

public ref struct AinbNodeBodiesSection
{
    public AinbNodeBodiesParameters Parameters;
    public AinbNodeBodiesChildNodeHeader ChildNodeHeader;

    public AinbNodeBodiesSection(ref RevrsReader reader)
    {
        Parameters = reader.Read<AinbNodeBodiesParameters>();
        ChildNodeHeader = reader.Read<AinbNodeBodiesChildNodeHeader>();

        // TODO: The rest of this section needs context to parse
    }
}
