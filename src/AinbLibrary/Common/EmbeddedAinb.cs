namespace AinbLibrary.Common;

public class EmbeddedAinb(string name, string category)
{
    public string Name { get; set; } = name;
    public string Category { get; set; } = category;
    public int Count { get; set; }
}
