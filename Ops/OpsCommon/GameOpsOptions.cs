using CommandLine;

namespace OpsCommon
{
    public class GameOpsOptions
    {
        [Option('d', "db", Required = true, HelpText = "Ops DB Api Server Uri")]
        public string OpsDBAPIUri { get; set; } = string.Empty;
    }
}
