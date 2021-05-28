using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TQA.NET;

namespace TQA.NET_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

            string tokenName = config["TQA:ApiClient"];
            string tokenValue = config["TQA:ApiKey"];

            var client = new TQAClient();
            var success = client.Login(tokenName, tokenValue).Result;

            if (success)
            {


                //LIST ALL SITES
                var sites = client.GetSites().Result;
                Console.WriteLine("==========SITES=========");
                foreach (var site in sites)
                {
                    Console.WriteLine($"{site.ID} - {site.Name}");
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

                //LIST ALL MACHINES
                var machines = client.GetMachines().Result;
                Console.WriteLine("==========MACHINES=========");
                foreach (var mach in machines)
                {
                    Console.WriteLine(mach.Name);
                }

                var testsite = sites.Where(s => s.Name == "Test Site").Single();
                var machine = machines.Where(m => m.Name == "Test Linac" && m.SiteId == testsite.ID).Single();
                var template = templates.Where(t => t.Name == "TSET_Dosimetry_Daily_v1").Single();
                var schedule = schedules.Where(s => s.MachineId == machine.Id && s.Name == "TSET Daily Dosimetry").Single();
                

            }
            else
            {
                Console.WriteLine("Couldn't log in. Check credentials!");
                Console.Read();
            }


            Console.WriteLine("Done");
            Console.Read();
        }
    }
}