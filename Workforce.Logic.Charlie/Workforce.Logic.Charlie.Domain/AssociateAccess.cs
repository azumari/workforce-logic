using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Charlie.Domain
{
    public class AssociateAccess
    {
        public async Task<List<Associate>> GrabFromFelice()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://ec2-54-173-46-251.compute-1.amazonaws.com/workforce-felice-rest/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/associate");

                var results = new List<Associate>();
                if (response.IsSuccessStatusCode)
                {
                    string holdingString = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<List<Associate>>(holdingString);
                }
                return results;
            }
        }
    }
}
