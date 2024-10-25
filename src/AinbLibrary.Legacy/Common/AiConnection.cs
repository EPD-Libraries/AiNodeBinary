using AinbLibrary.Common.Connections;
using AinbLibrary.Structures.Connections;

namespace AinbLibrary.Common;

public abstract class AiConnection
{
    public int Index { get; set; } = -1;

    public static AiConnection FromStruct<T>(AinbView ainb, T value) where T : struct
    {
        return value switch {
            AinbIONodeConnection ioConnection => new AiIOConection {
                Index = ioConnection.NodeIndex,
                Parameter = ainb.GetString(ioConnection.Parameter)
            },
            _ => throw new InvalidOperationException($"""
                Unexpected connection structure '{typeof(T)}'
                """)
        };
    }
}
