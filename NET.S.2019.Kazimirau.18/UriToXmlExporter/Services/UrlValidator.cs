using System;
using UriToXmlExporter.Interfaces;

namespace UriToXmlExporter.Services
{
    public class UrlValidator : IValidator<string>
    {
        public bool IsValid(string uriString)
        {
            return Uri.IsWellFormedUriString(uriString, UriKind.Absolute);
        }
    }
}
