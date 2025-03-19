using DagaCommon.Utility;

namespace DagaDB.DB
{
    public class CalculatorTest
    {
        public readonly Dictionary<object, TestTable> Entities = [];

        public bool AddEntity(TestTable addEntity)
        {
            if(CommonUtility.GetOrAddKey(addEntity) is not object key)
            {
                return false;
            }

            if (Entities.TryGetValue(key, out var originEntity))
            {
                CommonUtility.MergeProperties(originEntity, addEntity);
            }
            else
            {
                Entities.Add(key, addEntity);
            }

            return true;
        }
    }
}
