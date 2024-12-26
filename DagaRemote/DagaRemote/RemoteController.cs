using DagaCommon.Enums;
using DagaUtility;

public class RemoteController : Singleton<RemoteController>
{
    public RemoteOption RemoteOption { get; set; } = new();

    public bool StartProcess(ProcessType processType, Version version)
    {

        return true;
    }
}