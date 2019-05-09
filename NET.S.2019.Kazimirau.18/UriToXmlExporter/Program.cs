using System;
using System.Collections.Generic;
using UriToXmlExporter.Interfaces;
using UriToXmlExporter.Models;
using UriToXmlExporter.Services;
using UriToXmlExporter.Storages;

namespace UriToXmlExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> uris = new List<string>
            {
                "https://github.com/AnzhelikaKravchuk?tab=repositories",
                "https://git_hub..com/AnzhelikaKr.avchuk.?tab=.repositories",
                "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU",
                "https://habrahabr.ru/company/it-grad/blog/341486/",
                "http://habrahabr.ru/company///it-grad/?blog/341486/"
            };
            IValidator<string> validator = new UrlValidator();
            IParser<UrlAddress> parser = new UrlParser(validator, uris);
            IEnumerable<UrlAddress> urlAddresses = parser.Parse();
            IStorage<UrlAddress> storage = new XmlStorage(urlAddresses);
            storage.Save();
            Console.ReadLine();
        }
    }
}
