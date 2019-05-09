using System;
using System.Text.RegularExpressions;
using UriToXmlExporter.Interfaces;

namespace UriToXmlExporter.Services
{
    /// <summary>
    /// Class validates url
    /// </summary>
    public class UrlValidator : IValidator<string>
    {
        /// <summary>
        /// Method checks given url for correctness to the special rules
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        public bool IsValid(string urlString)
        {
            return Uri.IsWellFormedUriString(urlString, UriKind.Absolute) && ValidateUrl(urlString);
        }

        private bool ValidateUrl(string url)
        {
            //// <o_o> !!!!
            ////Regex regex = new Regex(@"^((http|https)://)?([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$");
            Regex regex = new Regex(@"^(https:\/\/){1}([a-z]+){1}\.(ru\/|com\/){1}([a-zA-Z0-9\(\)-\\/\?]+)?$");

            if (!regex.IsMatch(url))
            {
                return false;
            }

            return true;
        }
    }
}
