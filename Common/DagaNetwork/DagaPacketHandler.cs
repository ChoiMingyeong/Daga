using DagaUtility;
using System.Collections.Concurrent;
using System.Reflection;

namespace DagaNetwork
{
    internal class DagaPacketHandler : Singleton<DagaPacketHandler>
    {
        private ConcurrentDictionary<uint, IPacket> Packets { get; init; } = [];

        public DagaPacketHandler()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly
                .GetTypes()
                .Where(p => false == p.IsInterface && p.GetInterfaces().Contains(typeof(IPacket))))
            {
                if (Activator.CreateInstance(type) is IPacket packet)
                {
                    Packets.TryAdd(packet.PacketID, packet);
                }
            }
        }

        public Type? GetPacketType(uint packetID)
        {
            if (false == Packets.TryGetValue(packetID, out var packet))
            {
                return null;
            }

            return packet.GetType();
        }
    }
}
