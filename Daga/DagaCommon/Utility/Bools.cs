namespace DagaCommon.Utility
{
    public class Bools
    {
        private readonly List<Bool> _value = [];

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

        public Bools(params bool[] boolList)
        {
            var list = boolList.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                this[i] = list[i];
            }
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

        private void ValidateIndex(int index, out int listIndex, out byte bitIndex)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index must be greater than or equal to 0.");
            }

            listIndex = index / 8;
            bitIndex = (byte)(index % 8);

            // 필요한 경우 Bool 객체 추가
            while (_value.Count <= listIndex)
            {
                _value.Add(new Bool([.. Enumerable.Repeat(false, (_value.Count == listIndex) ? bitIndex + 1 : 8)]));
            }

        }
    }
}