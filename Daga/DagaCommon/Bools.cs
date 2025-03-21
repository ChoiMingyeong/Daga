namespace DagaCommon
{
    public class Bools
    {
        private List<Bool> _value = [];

        public bool this[int index]
        {
            get
            {
                ValidateIndex(index, out int listIndex, out byte bitIndex);
                return _value[listIndex][bitIndex];
            }
            set
            {
                ValidateIndex(index, out int listIndex, out byte bitIndex);
                _value[listIndex][bitIndex] = value;
            }
        }

        public Bools(params IEnumerable<bool> boolList)
        {
            var list = boolList.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                this[i] = list[i];
            }
        }

        public Bools(int size = 0, params IEnumerable<byte> bytes)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than 0.");
            }

            int listSize = (size / 8) + 1;
            byte bitSize = (byte)(size % 8);
            var list = bytes.ToList();
            for (int i = 0; i < listSize; ++i)
            {
                _value.Add(new Bool(list.Count <= i ? (byte)0 : list[i], i == listSize - 1 ? bitSize : (byte)8));
            }
        }

        public Bools(int size = 0, params IEnumerable<ushort> ushorts) : this(size, ushorts.SelectMany(ToBytes))
        {
        }

        public Bools(int size = 0, params IEnumerable<uint> uints) : this(size, uints.SelectMany(ToBytes))
        {
        }

        public Bools(int size = 0, params IEnumerable<ulong> ulongs) : this(size, ulongs.SelectMany(ToBytes))
        {
        }

        private static IEnumerable<byte> ToBytes(ushort value)
        {
            yield return (byte)(value & 0xFF);
            yield return (byte)((value >> 8) & 0xFF);
        }

        private static IEnumerable<byte> ToBytes(uint value)
        {
            yield return (byte)(value & 0xFF);
            yield return (byte)((value >> 8) & 0xFF);
            yield return (byte)((value >> 16) & 0xFF);
            yield return (byte)((value >> 24) & 0xFF);
        }

        private static IEnumerable<byte> ToBytes(ulong value)
        {
            yield return (byte)(value & 0xFF);
            yield return (byte)((value >> 8) & 0xFF);
            yield return (byte)((value >> 16) & 0xFF);
            yield return (byte)((value >> 24) & 0xFF);
            yield return (byte)((value >> 32) & 0xFF);
            yield return (byte)((value >> 40) & 0xFF);
            yield return (byte)((value >> 48) & 0xFF);
            yield return (byte)((value >> 56) & 0xFF);
        }

        public Bools(in Bools other)
        {
            _value = new Bools(other.ToList())._value;
        }

        public void Add(bool b)
        {
            int index = Count();
            ValidateIndex(index, out _, out _);
            this[index] = b;
        }

        public void AddRange(IEnumerable<bool> boolList)
        {
            foreach (var b in boolList)
            {
                Add(b);
            }
        }

        public int Count()
        {
            if (_value.Count == 0)
            {
                return 0;
            }

            return _value.Count * 8 - (8 - _value[^1].Count());
        }

        public void RemoveAt(byte index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index must be greater than or equal to 0.");
            }

            if (index >= _value.Count * 8)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            int listIndex = index / 8;
            byte bitIndex = (byte)(index % 8);

            _value[listIndex].RemoveAt(bitIndex);
            for (int i = listIndex + 1; i < _value.Count; i++)
            {
                _value[i - 1].Add(_value[i][0]);
                _value[i].RemoveAt(0);
            }

            if (_value[^1].Count() == 0)
            {
                _value.RemoveAt(_value.Count - 1);
            }
        }

        public void Clear()
        {
            _value.Clear();
        }

        public IEnumerable<bool> ToEnumerable()
        {
            for (var i = 0; i < _value.Count; i++)
            {
                foreach (var b in _value[i].ToEnumerable())
                {
                    yield return b;
                }
            }
        }

        public List<bool> ToList()
        {
            return [.. ToEnumerable()];
        }

        public bool[] ToArray()
        {
            return [.. ToEnumerable()];
        }

        public IEnumerable<byte> ToBytes()
        {
            return _value.Select(p => p.ToByte());
        }

        public IEnumerable<ushort> ToUShorts()
        {
            for (int i = 0; i < _value.Count; i += 2)
            {
                ushort value = 0;
                int remaining = Math.Min(2, _value.Count - i); // 남은 개수 확인

                for (int j = 0; j < remaining; j++)
                {
                    value |= (ushort)(_value[i + j].ToByte() << (j * 8));
                }

                yield return value;
            }
        }

        public IEnumerable<uint> ToUInts()
        {
            for (int i = 0; i < _value.Count; i += 4)
            {
                uint value = 0;
                int remaining = Math.Min(4, _value.Count - i); // 남은 개수 확인

                for (int j = 0; j < remaining; j++)
                {
                    value |= (uint)(_value[i + j].ToByte() << (j * 8));
                }

                yield return value;
            }
        }

        public IEnumerable<ulong> ToULongs()
        {
            for (int i = 0; i < _value.Count; i += 8)
            {
                ulong value = 0;
                int remaining = Math.Min(8, _value.Count - i); // 남은 개수만큼 반복

                for (int j = 0; j < remaining; j++)
                {
                    value |= (ulong)_value[i + j].ToByte() << (j * 8);
                }

                yield return value;
            }
        }

        private void ValidateIndex(int index, out int listIndex, out byte bitIndex)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index must be greater than or equal to 0.");
            }

            listIndex = index / 8;
            bitIndex = (byte)(index % 8);

            if (_value.Count != 0 && listIndex >= _value.Count)
            {
                var addCount = 8 - _value[^1].Count();
                for (byte i = 0; i < addCount; ++i)
                {
                    _value[^1].Add(false);
                }
            }

            while (_value.Count <= listIndex)
            {
                _value.Add(new Bool(0, (byte)(_value.Count == listIndex ? bitIndex + 1 : 8)));
            }
        }
    }
}