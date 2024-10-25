using AinbLibrary.Legacy.Common.Connections;
using AinbLibrary.Legacy.Structures.Connections;

namespace AinbLibrary.Legacy.Common;

public abstract class AiConnection
{
    public int Index { get; set; } = -1;

    public static AiConnection FromStruct<T>(AinbView ainb, T value) where T : struct
    {
        return value switch {
            AinbIoNodeConnection ioConnection => new AiIoConection {
                Index = ioConnection.NodeIndex,
                Parameter = ainb.GetString(ioConnection.Parameter)
            },
            _ => throw new InvalidOperationException($"""
                Unexpected connection structure '{typeof(T)}'
                """)
        };
    }
}
