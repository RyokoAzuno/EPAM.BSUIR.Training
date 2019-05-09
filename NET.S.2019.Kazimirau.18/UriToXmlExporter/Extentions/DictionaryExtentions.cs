using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace UriToXmlExporter.Extentions
{
    /// <summary>
    /// Extension methods for Dictionary class
    /// </summary>
    public static class DictionaryExtentions
    {
        /// <summary>
        /// Converts NameValueCollection into Dictionary
        /// </summary>
        public static Dictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            return collection.Cast<string>().ToDictionary(k => k, v => collection[v]);
        }
    }
}
