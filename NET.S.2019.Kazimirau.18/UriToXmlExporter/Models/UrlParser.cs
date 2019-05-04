using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UriToXmlExporter.Extentions;

namespace UriToXmlExporter.Models
{
    public class UrlParser
    {
        private readonly List<string> _uris;

        private List<UrlAddress> _urlAddresses;

        public UrlParser(params string[] uris)
        {
            _uris = new List<string>(uris);
            _urlAddresses = new List<UrlAddress>();
        }

        public IEnumerable<UrlAddress> Parse()
        {
            foreach (var item in _uris)
            {
                Uri uri = new Uri(item);

                _urlAddresses.Add(new UrlAddress
                {
                    Scheme = uri.Scheme,
                    Host = uri.Host,
                    Segments = uri.Segments.Where(s => s != "/").Select(x => x.TrimEnd('/')).ToArray(),
                    Parameters = HttpUtility.ParseQueryString(uri.Query).ToDictionary()
                });
            }


            return _urlAddresses;
        }
    }
}
