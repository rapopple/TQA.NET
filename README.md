# TQA.NET
.NET Wrapper for Image Owl Total QA

### How To Use
#### Get your API Credentials
![ImageOwl Image](https://svcika.dm2304.livefilestore.com/y4mQgt3UAgwa6gJfjjASm6Ih9aRgmfGPGcTnW6SyiBBY_35Ttw4PFHE_RQxl9MNPunihAM9_cmc6pM5HcOQUaoeqcKRI9TF5FdzdjFLYpHyUKzdCND3L8U7gzvw2S7yGiRjMkQe9Mk8yWBX4tIR5p3bHaWAch4Gd95d58K5t0wRXbwxCdtvyzGG1tk_RSBMju7eG16Ncvc3HwvXQUpnUBMSIw?width=680&height=284&cropmode=none)

#### Do This
```csharp
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
```
