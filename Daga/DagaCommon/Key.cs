﻿namespace DagaCommon
{
    public class Key
    {
        public object?[] KeyValues { get; }

        public Key(params object?[] keyValues)
        {
            KeyValues = keyValues ?? throw new ArgumentNullException(nameof(keyValues));
        }

        public override bool Equals(object? obj)
        {
            if (obj is Key otherKey)
            {
                return KeyValues.SequenceEqual(otherKey.KeyValues);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked // 오버플로우 무시 (더 균일한 해시 분포)
            {
                int hash = 17;
                foreach (var keyValue in KeyValues)
                {
                    hash = hash * 31 + (keyValue?.GetHashCode() ?? 0);
                }
                return hash;
            }
        }

        public override string ToString()
        {
            return string.Join(",", KeyValues);
        }
    }
}
