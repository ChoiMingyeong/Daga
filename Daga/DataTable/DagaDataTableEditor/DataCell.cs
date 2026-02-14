using System.Text.Json.Serialization;

namespace DagaDataTableEditor
{
    public class DataCell
    {
        [JsonIgnore]
        public DataColumnDefinition ColumnDef { get; set; }

        #region 파일 저장용
        public Id<DataColumnDefinition> ColumnId { get; set; }

        public void SetColumnDef(ref IDictionary<Id<DataColumnDefinition>, DataColumnDefinition> colDefs)
        {
            if (!colDefs.TryGetValue(ColumnId, out DataColumnDefinition? colDef))
            {
                throw new ArgumentException($"Column definition with id {ColumnId} not found in provided column definitions.");
            }
            ColumnDef = colDef;
        }
        #endregion

        public string? Value { get; set; } = string.Empty;

        public bool IsValid()
        {
            if (colDef.Id != ColumnId)
            {
                throw new ArgumentException($"Column definition id {colDef.Id} does not match cell column id {ColumnId}");
            }

            // null값 허용 체크
            if (colDef.IsNullable)
            {
                if (string.IsNullOrEmpty(Value))
                {
                    return true;
                }


            }
            else if (string.IsNullOrEmpty(Value))
            {
                return false;
            }

        }
    }
}
