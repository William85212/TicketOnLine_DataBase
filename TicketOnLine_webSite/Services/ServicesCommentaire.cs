using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketOnLine_webSite.Models;

namespace TicketOnLine_webSite.Services
{
    public class ServicesCommentaire
    {
        public static async Task<List<CommentaireWeb>> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await client.GetAsync("Commentaire");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<CommentaireWeb>>(json);
        }

        public static async void Post(CommentaireWeb web)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");
            string json = JsonConvert.SerializeObject(web);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync("Commentaire", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}
