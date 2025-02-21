using System.ComponentModel.DataAnnotations;

namespace OpsCommon
{
    public class Gate
    {
        public string Version { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
    }
}
