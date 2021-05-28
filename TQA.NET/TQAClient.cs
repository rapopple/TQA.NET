using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TQA.NET
{
    public class TQAClient : HttpClient
    {
        private Uri baseAddress = new Uri("https://tqa.imageowl.com/");
        const string JSON = "application/json";
        private string accessToken = "";

        public TQAClient()
        {
            this.BaseAddress = baseAddress;
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON));
        }

        public async Task<bool> Login(string tokenName, string tokenValue)
        {
            var creds = new
            {
                client_id = tokenName,
                client_secret = tokenValue,
                grant_type = "client_credentials"
            };
            var content = new StringContent(JsonConvert.SerializeObject(creds), Encoding.UTF8, JSON);
            var result = await this.PostAsync("api/rest/oauth", content);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeAnonymousType(response, new { access_token = "" });
                accessToken = json.access_token;
                return true;
            }
            return false; //Not successful
        }

        public async Task<List<Site>> GetSites()
        {
            var sites = await TryGet("api/rest/sites", (resp) =>
            {
                return JsonConvert.DeserializeAnonymousType(resp, new { sites = new Site[0] }).sites.ToList();
            });
            if (sites.IsSuccess) { return sites.Response; }
            throw new Exception("Couldn't get sites");
        }

        public async Task<List<Schedule>> GetSchedules()
        {
            var schedules = await TryGet("api/rest/schedules", (resp) =>
            {
                return JsonConvert.DeserializeAnonymousType(resp, new { schedules = new Schedule[0] }).schedules.ToList();
            });
            if (schedules.IsSuccess) { return schedules.Response; }
            throw new Exception("Couldn't get schedules");
        }

        public async Task<List<Template>> GetTemplates()
        {
            var templates = await TryGet("api/rest/templates", (resp) =>
            {
                return JsonConvert.DeserializeAnonymousType(resp, new { templates = new Template[0] }).templates.ToList();
            });
            if (templates.IsSuccess) { return templates.Response; }
            throw new Exception("Couldn't get templates");
        }
        public async Task<List<Machine>> GetMachines()
        {
            var machines = await TryGet("api/rest/machines", (resp) =>
            {
                return JsonConvert.DeserializeAnonymousType(resp, new { machines = new Machine[0] }).machines.ToList();
            });
            if (machines.IsSuccess) { return machines.Response; }
            throw new Exception("Couldn't get machines");
        }
        #region CLIENT PLUMBING
        private async Task<TResponse<T>> TryGet<T>(string apiAddress, Func<string, T> responseFunction) where T : new()
        {
            var req = new HttpRequestMessage(HttpMethod.Get, apiAddress);
            req.Headers.Add("Authorization", "Bearer " + accessToken);
            var result = await this.SendAsync(req);
            var attemptT = new TResponse<T>();

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                try
                {
                    attemptT.Response = responseFunction(response);
                    attemptT.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    //TODO Log exception
                    Debug.WriteLine(ex.Message);
                    attemptT.IsSuccess = false;
                }
            }
            return attemptT; ;
        }
        #endregion
    }

}
