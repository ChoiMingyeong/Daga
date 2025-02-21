using CommandLine;

namespace OpsCommon
{
    public class OpsDBAPIOptions
    {
        [Option('c', "connection", Required = true, HelpText = "DB Connection String")]
        public string DBConnetcionString { get; set; } = string.Empty;

        [Option('p', "http", Required = false, HelpText = "Http Port")]
        public int HttpPort { get; set; }

        [Option('s', "https", Required = false, HelpText = "Https Port")]
        public int HttpsPort { get; set; }
    }
}
