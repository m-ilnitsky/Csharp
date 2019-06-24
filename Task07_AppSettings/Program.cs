using System;
using System.Configuration;

namespace Task07_AppSettings
{
    internal class Program
    {
        private static void Main()
        {
            var siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
            var siteName = ConfigurationManager.AppSettings["Name"];

            Console.WriteLine("SiteUrl=" + siteUrl);
            Console.WriteLine("Name=" + siteName);
        }
    }
}
