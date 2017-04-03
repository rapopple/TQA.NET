using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TQA.NET;

namespace TQA.NET_Console
{
    class Program
    {
        static string tokenName = "";
        static string tokenValue = "";

        static void Main(string[] args)
        {
            var client = new TQAClient();
            var success = client.Login(tokenName, tokenValue).Result;

            if (success)
            {
                //LIST ALL SITES
                var sites = client.GetSites().Result;
                Console.WriteLine("==========SITES=========");
                foreach (var site in sites)
                {
                    Console.WriteLine(site.ID);
                }

                //LIST ALL TEMPLATES
                var templates = client.GetTemplates().Result;
                Console.WriteLine("==========TEMPLATES=========");
                foreach (var temp in templates)
                {
                    Console.WriteLine(temp.Name);
                }

                //LIST ALL SCHEDULES
                var schedules = client.GetSchedules().Result;
                Console.WriteLine("==========SCHEDULES=========");
                foreach (var sched in schedules)
                {
                    Console.WriteLine(sched.Name);
                }
            }
            else
            {
                Console.WriteLine("Couldn't log in. Check credentials!");
                Console.Read();
            }
        }
    }
}
