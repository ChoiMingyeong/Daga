using StackExchange.Redis;
using System.Collections.Concurrent;
using System.Text.Json;
using static StackExchange.Redis.RedisChannel;

namespace GateHub
{
    public class RedisService
    {
        private const string GateToken = "g";

        private Lazy<ConcurrentDictionary<string, string>>? _gates = null;
        public ConcurrentDictionary<string, string> Gates
        {
            get
            {
                _gates ??= new();
                return _gates.Value;
            }
        }

        private Dictionary<string, RedisChannel> _channels = new()
        {
            { "create", new RedisChannel("create", PatternMode.Literal) },
            { "update", new RedisChannel("update", PatternMode.Literal) },
            { "delete", new RedisChannel("delete", PatternMode.Literal) },
        };

        private readonly IDatabase _db;
        private readonly ISubscriber _subscriber;

        public RedisService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
            if (_db.HashGetAll(GateToken) is HashEntry[] hashEntries)
            {
                foreach (var gate in hashEntries)
                {
                    if (gate.Name.ToString() is string version
                        && gate.Value.ToString() is string state)
                    {
                        Gates.TryAdd(version, state);
                    }
                }
            }

            _subscriber = redis.GetSubscriber();
            _subscriber.Subscribe(_channels["create"], (_, message) =>
            {
                if (false == message.IsNullOrEmpty)
                {
                    if (JsonSerializer.Deserialize<OpsCommon.Gate>(message.ToString()) is OpsCommon.Gate gate)
                    {
                        SubscribeCreate(gate);
                    }
                }
            });
            _subscriber.Subscribe(_channels["update"], (_, message) =>
            {
                if (false == message.IsNullOrEmpty)
                {
                    if (JsonSerializer.Deserialize<OpsCommon.Gate>(message.ToString()) is OpsCommon.Gate gate)
                    {
                        SubscribeUpdate(gate);
                    }
                }
            });
            _subscriber.Subscribe(_channels["delete"], (_, message) =>
            {
                if (false == message.IsNullOrEmpty)
                {
                    if (message.ToString() is string version)
                    {
                        SubscribeDelete(version);
                    }
                }
            });
        }

        public List<OpsCommon.Gate> GetGateList() => Gates.Select(p => new OpsCommon.Gate() { Version = p.Key, State = p.Value }).ToList();

        public async Task<bool> PublishCreateAsync(OpsCommon.Gate gate)
        {
            await _db.HashSetAsync(GateToken, gate.Version, gate.State);
            if (_channels.TryGetValue("create", out var channel))
            {
                await _subscriber.PublishAsync(channel, JsonSerializer.Serialize(gate));
                return true;
            }

            return false;
        }
        public async Task<bool> PublishUpdateAsync(OpsCommon.Gate gate)
        {
            await _db.HashSetAsync(GateToken, gate.Version, gate.State);
            if (_channels.TryGetValue("update", out var channel))
            {
                await _subscriber.PublishAsync(channel, JsonSerializer.Serialize(gate));
                return true;
            }

            return false;
        }
        public async Task<bool> PublishDeleteAsync(string version)
        {
            await _db.HashDeleteAsync(GateToken, version);
            if (_channels.TryGetValue("delete", out var channel))
            {
                await _subscriber.PublishAsync(channel, version);
                return true;
            }

            return false;
        }

        private void SubscribeCreate(OpsCommon.Gate gate)
        {
            if (false == Gates.ContainsKey(gate.Version))
            {
                Gates.TryAdd(gate.Version, gate.State);
            }
        }

        private void SubscribeUpdate(OpsCommon.Gate gate)
        {
            if (true == Gates.ContainsKey(gate.Version))
            {
                Gates[gate.Version] = gate.State;
            }
        }
        private void SubscribeDelete(string version)
        {
            Gates.TryRemove(version, out _);
        }
    }
}
