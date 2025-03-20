namespace DagaCommon.Utility
{
    public class Bool
    {
        private static readonly byte[] _flags = [1, 2, 4, 8, 16, 32, 64, 128];

        private byte _value = 0;

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
                if(value)
                {
                    _value |= _flags[index];
                }
                else
                {
                    _value &= (byte)~_flags[index];
                }
            }
        }

        public Bool(IEnumerable<bool> boolList)
        {
            var list = boolList.Take(8).ToList(); // 최대 8개만 가져와 리스트로 변환
            byte length = (byte)list.Count;

            for (byte i = 0; i < length; i++)
            {
                this[i] = list[i];
            }
        }

        public Bool(params bool[] boolList) : this((IEnumerable<bool>)boolList)
        {
        }

        public IEnumerable<bool> ToEnumerable()
        {
            for (byte i = 0; i < _flags.Length; i++)
            {
                yield return (_value & _flags[i]) != 0;
            }
        }

        public List<bool> ToList()
        {
            return ToEnumerable().ToList();
        }

        public bool[] ToArray()
        {
            return ToEnumerable().ToArray();
        }
        private void ValidateIndex(byte index)
        {
            if (index >= 8)
            {
                throw new IndexOutOfRangeException("Index must be between 0 and 7.");
            }
        }
    }
}
