using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Services
{
    public class ServicesSalle
    {

        public static async Task<List<SalleWeb>> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await client.GetAsync("Salle");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<SalleWeb>>(json);
        }
    }
}
