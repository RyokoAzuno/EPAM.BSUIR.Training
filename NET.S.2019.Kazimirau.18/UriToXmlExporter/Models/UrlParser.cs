using System;
using System.Linq;
using System.Web;
using UriToXmlExporter.Extentions;

namespace UriToXmlExporter.Models
{
    public class UrlParser
    {
        private string _uri;
        private UrlAddress _urlAddress;

        public UrlParser(string uri)
        {
            _uri = uri;
        }

        public UrlAddress Parse()
        {
            Uri uri = new Uri(_uri);

            _urlAddress = new UrlAddress();
            _urlAddress.Scheme = uri.Scheme;
            _urlAddress.Host = uri.Host;
            _urlAddress.Segments = uri.Segments.Where(s => s != "/").Select(x => x.TrimEnd('/')).ToArray();
            _urlAddress.Parameters = HttpUtility.ParseQueryString(uri.Query).ToDictionary();

            return _urlAddress;
        }
    }
}
