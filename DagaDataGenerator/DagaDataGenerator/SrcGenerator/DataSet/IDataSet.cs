namespace DagaDataGenerator.SrcGenerator.DataSet;

/// <summary>
/// DataSet 소스코드의 형태는
/// <br/>public class {DataSetName} : IDataSet
/// <br/>{
/// <br/>    public {PropertyType} {PropertyName} { get; set; }
/// <br/>}
/// </summary>
public interface IDataSet
{
    public uint UID { get; init; }
}