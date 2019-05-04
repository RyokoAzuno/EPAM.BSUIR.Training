using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriToXmlExporter.Models;

namespace UriToXmlExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            //UrlParser parser = new UrlParser("https://github.com/AnzhelikaKravchuk?tab=repositories");
            //UrlParser parser = new UrlParser("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU");
            UrlParser parser = new UrlParser("https://habrahabr.ru/company/it-grad/blog/341486/");
            UrlAddress urlAddress = parser.Parse();
            Console.ReadLine();
        }
    }
}
