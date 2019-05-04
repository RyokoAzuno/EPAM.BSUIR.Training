using System.Collections.Generic;

namespace UriToXmlExporter.Interfaces
{
    public interface IStorage<T> where T: class
    {
        void Save();
        IEnumerable<T> Load();
    }
}
