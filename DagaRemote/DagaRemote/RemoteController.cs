using DagaCommon.Enums;
using DagaUtility;

public class RemoteController : Singleton<RemoteController>
{
    public RemoteOption RemoteOption { get; set; } = new();
    private Dictionary<int, Process> _detachProcesses=[];

    public bool StartProcess(ProcessType processType, Version version)
    {

        return true;
    }

    public bool StopProcess(Version version, pararms int processID)
    {
        return true;
    }
}