using System.Collections.Generic;

namespace UriToXmlExporter.Models
{
    public class UrlAddress
    {
        public string Scheme { get; set; }

        public string Host { get; set; }

        public string[] Segments { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
