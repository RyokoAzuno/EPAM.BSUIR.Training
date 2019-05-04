using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace UriToXmlExporter.Extentions
{
    public static class DictionaryExtentions
    {
        public static Dictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            return collection.Cast<string>().ToDictionary(k => k, v => collection[v]);
        }
    }
}
