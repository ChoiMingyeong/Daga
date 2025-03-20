namespace DagaCommon.Utility
{
    public class Bool
    {
        private static readonly byte[] _flags = [1, 2, 4, 8, 16, 32, 64, 128];

        private byte _value = 0;

        private byte _capacity = 0;

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

                if (index + 1 >= _capacity)
                {
                    _capacity = (byte)(index + 1);
                }
            }
        }

        public Bool(params bool[] boolList)
        {
            var list = boolList.Take(8).ToList(); // 최대 8개만 가져와 리스트로 변환
            byte length = (byte)list.Count;

            for (byte i = 0; i < length; i++)
            {
                this[i] = list[i];
            }

            _capacity = length;
        }

        public Bool(byte value)
        {
            _value = value;
            _capacity = 8;
        }

        public void Add(bool b)
        {
            if (_capacity >= 8)
            {
                throw new IndexOutOfRangeException("Bool can only contain up to 8 values.");
            }

            this[_capacity] = b;
        }

        public byte Count()
        {
            return _capacity;
        }

        public void RemoveAt(byte index)
        {
            ValidateIndex(index);
            if (index >= _capacity)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            _value = (byte)((_value & ((1 << index) - 1)) | ((_value >> (index + 1)) << index));
            _capacity--;
        }

        public void Clear()
        {
            _value = 0;
            _capacity = 0;
        }

        public IEnumerable<bool> ToEnumerable()
        {
            for (byte i = 0; i < _capacity; i++)
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