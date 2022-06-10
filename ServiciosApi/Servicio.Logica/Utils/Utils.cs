using System.Collections.Specialized;
using System.Text;
using System.Collections.Generic;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.NetworkInformation;

namespace Servicio.Logica
{
    public static class Utils
    {
        /// <summary>
        /// Obtener la IP local de nuestro equipo 
        /// </summary>
        /// <returns>actual IP de nuestro equipo</returns>
        public static string GetCurrentLocalIps()
        {
            List<string> localIPs = new List<string>();
            IPHostEntry host = Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIPs.Add(ip.ToString());
                }
            }
            return string.Join(", ", localIPs);
        }


        /// <summary>
        /// Obtener la IP local de nuestro equipo 
        /// </summary>
        /// <example>
        /// <code>
        ///    string url = "http://www.contoso.com:8080/letters/readme.html";
        ///     Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
        ///                        RegexOptions.None, TimeSpan.FromMilliseconds(150));
        ///    Match m = r.Match(url);
        ///   if (m.Success)
        ///      Console.WriteLine(m.Result("${proto}${port}"));
        ///  The example displays the following output:    http:8080
        /// </code>
        /// </example>
        /// <returns>actual IP de nuestro equipo</returns>
        public static (string,string) GetProtocoloAdPortOfUrl(string url)
        {
            if(!string.IsNullOrEmpty(url))
            {
                Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                                    RegexOptions.None, TimeSpan.FromMilliseconds(150));
                Match m = r.Match(url);
                if (m.Success)
                    return (m.Result("${proto}"),m.Result("${port}"));
            }
            return ("","");
        }   
    }
}