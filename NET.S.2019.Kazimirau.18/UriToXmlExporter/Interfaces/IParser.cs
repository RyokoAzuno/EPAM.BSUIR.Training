using System.Collections.Generic;

namespace UriToXmlExporter.Interfaces
{
    public interface IParser<out T> where T : class
    {
        IEnumerable<T> Parse();
    }
}
