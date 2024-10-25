namespace AinbLibrary;

public struct AinbVersion
{
    public byte Major;
    public byte Minor;
    public ushort Revision;

    public readonly override string ToString()
    {
        return $"{Major}.{Minor}.{Revision}";
    }
}
