namespace DagaCommon
{
    public class Bool
    {
        private static readonly byte[] _flags = [1, 2, 4, 8, 16, 32, 64, 128];

        private byte _value = 0;

        private byte _size = 0;

        public bool this[byte index]
        {
            get
            {
                ValidateIndex(index);
                return (_value & _flags[index]) != 0;
            }
            set
            {
                ValidateIndex(index);
                if (value)
                {
                    _value |= _flags[index];
                }
                else
                {
                    _value &= (byte)~_flags[index];
                }

                if (index + 1 > _size)
                {
                    _size = (byte)(index + 1);
                }
            }
        }

        public Bool(params IEnumerable<bool> boolList)
        {
            var list = boolList.Take(8).ToList(); // 최대 8개만 가져와 리스트로 변환
            byte length = (byte)list.Count;

            for (byte i = 0; i < length; i++)
            {
                this[i] = list[i];
            }

            _size = length;
        }

        public Bool(byte value, byte size = 8)
        {
            if (_size > 8)
            {
                throw new Exception("Size must be between 0 and 8.");
            }

            _value = (byte)(value & (byte.MaxValue >> (8 - size)));
            _size = size;
        }

        public void Add(bool b)
        {
            if (_size >= 8)
            {
                throw new Exception("Size must be between 0 and 8.");
            }

            this[_size] = b;
        }

        public byte Count()
        {
            return _size;
        }

        public void RemoveAt(byte index)
        {
            ValidateIndex(index);
            if (index >= _size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            _value = (byte)(_value & (1 << index) - 1 | _value >> index + 1 << index);
            _size--;
        }

        public void Clear()
        {
            _value = 0;
            _size = 0;
        }

        public IEnumerable<bool> ToEnumerable()
        {
            for (byte i = 0; i < _size; i++)
            {
                yield return (_value & _flags[i]) != 0;
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

        public byte ToByte()
        {
            return _value;
        }

        private static void ValidateIndex(byte index)
        {
            if (index >= 8)
            {
                throw new IndexOutOfRangeException("Index must be between 0 and 7.");
            }
        }
    }
}