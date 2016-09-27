using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Grace.Domain.Helpers
{
  public class Consumers
  {
    public async Task<List<AssociateDto>> ConsumeAssociatesFromAPI()
    {
      using (var client = new HttpClient())
      {
        // New code:
        client.BaseAddress = new Uri("http://ec2-54-173-46-251.compute-1.amazonaws.com/workforce-felice-rest/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync("api/associate");
        List<AssociateDto> trainee = new List<AssociateDto>();
        if (response.IsSuccessStatusCode)
        {


          string holdingString = await response.Content.ReadAsStringAsync();
          trainee = JsonConvert.DeserializeObject<List<AssociateDto>>(holdingString);
        }

        return trainee;
      }
    }
  }
}