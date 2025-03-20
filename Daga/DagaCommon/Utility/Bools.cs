namespace DagaCommon.Utility
{
    public class Bools
    {
        private List<Bool> _value = [];

        private byte _lastIndex = 0;

        public bool this[int index]
        {
            get
            {
                ValidateIndex(index);
                int listIndex = index / 8;
                byte boolIndex = (byte)(index % 8);

                // 필요한 경우 Bool 객체 추가
                while (_value.Count <= listIndex)
                {
                    _value.Add(new Bool());
                }

                return _value[listIndex][boolIndex];
            }
            set
            {
                ValidateIndex(index);
                int listIndex = index / 8;
                byte boolIndex = (byte)(index % 8);

                // 필요한 경우 Bool 객체 추가
                while (_value.Count <= listIndex)
                {
                    _value.Add(new Bool());
                }

                // 값 설정
                _value[listIndex][boolIndex] = value;

                // _lastIndex 업데이트
                if (listIndex == _value.Count - 1 && boolIndex > _lastIndex)
                {
                    _lastIndex = boolIndex;
                }
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
            for(var i = 0; i < _value.Count; i++)
            {
                foreach (var b in _value[i].ToEnumerable().Take(_lastIndex + 1))
                {
                    yield return b;
                }
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

        private static void ValidateIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index must be greater than or equal to 0.");
            }
        }
    }
}