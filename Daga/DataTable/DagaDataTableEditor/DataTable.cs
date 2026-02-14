namespace DagaDataTableEditor
{
    public class DataTable : BaseEntity<DataTable>
    {
        private readonly IdGenerator _idGenerator = new();

        public Dictionary<Id<DataColumnDefinition>, DataColumnDefinition> ColumnDefinitions { get; private set; } = [];

        public List<DataRow> Rows { get; private set; } = [];

        /// <summary>
        /// 테이블에 새로운 컬럼을 추가합니다.
        /// </summary>
        /// <param name="columnName">추가할 컬럼의 이름입니다.</param>
        /// <param name="dataType">컬럼의 데이터 타입입니다.</param>
        /// <param name="defaultValue">기본값입니다. null일 경우 해당 타입의 기본값이 설정됩니다.</param>
        /// <exception cref="ArgumentException">이미 같은 이름의 컬럼이 존재하거나, 기본값이 해당 데이터 타입으로 변환될 수 없을 때 발생합니다.</exception>
        /// <exception cref="NotSupportedException">지원하지 않는 데이터 타입일 때 발생합니다.</exception>
        public void AddColumn(string columnName, DataTypes dataType, bool isUnsigned, bool isNullable, string? defaultValue)
        {
            // 중복 컬럼 이름 체크
            if (ColumnDefinitions.Values.Any(cd => cd.Name == columnName))
            {
                throw new ArgumentException($"Column with name '{columnName}' already exists.", nameof(columnName));
            }

            // 데이터 타입 변환 확인
            Type type;
            try
            {
                type = DataTypeConverter.ConvertDataType(dataType, isUnsigned);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // 지원하지 않는 타입일 경우
                throw new NotSupportedException($"Data type '{dataType}' is not supported.", ex);
            }

            // null 허용 여부에 따른 기본값 체크
            if (!isNullable && defaultValue is null)
            {
                throw new ArgumentException($"Default value must be provided for non-nullable type '{type.Name}'.", nameof(defaultValue));
            }

            // 기본값 유효성 검사
            if (defaultValue is not null)
            {
                try
                {
                    _ = Convert.ChangeType(defaultValue, type);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Default value '{defaultValue}' could not be converted to type '{type.Name}'.", nameof(defaultValue), ex);
                }
            }

            // 컬럼 추가
            DataColumnDefinition newColumnDef = new()
            {
                Id = _idGenerator.Next<DataColumnDefinition>(),
                Name = columnName,
                DataType = type,
                IsUnsigned = isUnsigned,
                DefaultValue = defaultValue,
            };
            ColumnDefinitions.Add(newColumnDef.Id, newColumnDef);

            // 기존 행들에 대해 새 컬럼의 기본값 추가
            foreach (var row in Rows)
            {
                row.Cells.Add(new DataCell()
                {
                    ColumnDef = newColumnDef,
                    ColumnId = newColumnDef.Id,
                    Value = newColumnDef.DefaultValue,
                });
            }
        }

        public void AddRow()
        {
            DataRow newRow = new()
            {
                Id = IdGenerator.Next<DataRow>(),
            };
            newRow.Cells = [.. ColumnDefinitions.Select(cd => new DataCell()
                {
                    ColumnId = cd.Id,
                    RowId = newRow.Id,
                    Value = cd.DefaultValue,
                })];
            Rows.Add(newRow);
        }
    }
}
