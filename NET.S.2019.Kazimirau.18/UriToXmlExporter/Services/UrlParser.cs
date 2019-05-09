using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UriToXmlExporter.Extentions;
using UriToXmlExporter.Interfaces;
using UriToXmlExporter.Loggers;
using UriToXmlExporter.Models;

namespace UriToXmlExporter.Services
{
    /// <summary>
    /// Class parses url collection into list of UrlAddress
    /// </summary>
    public class UrlParser : IParser<UrlAddress>
    {
        private readonly List<string> _uris;

        private List<UrlAddress> _urlAddresses;

        private IValidator<string> _validator;

        public UrlParser(IValidator<string> validator, IEnumerable<string> uris)
        {
            _uris = new List<string>(uris);
            _urlAddresses = new List<UrlAddress>();
            _validator = validator;
        }

        /// <summary>
        /// Parse a collection of url
        /// </summary>
        public IEnumerable<UrlAddress> Parse()
        {
            foreach (var item in _uris)
            {
                if (!_validator.IsValid(item))
                {
                    MyLogger.GetLogger().Info($"Invalid Url: {item}");
                    continue;
                }

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
