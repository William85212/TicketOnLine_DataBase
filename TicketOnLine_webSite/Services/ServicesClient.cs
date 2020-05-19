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
    public class ServicesClient
    {
        public static async Task<List<ClientsWeb>> Get()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await _client.GetAsync("Clients");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<ClientsWeb>>(json);
        }

        public static async Task<ClientsWeb> Get(int id)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await _client.GetAsync("Clients/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ClientsWeb>(json);
        }


        public static async void Post(ClientsWeb cw)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");
            string json = JsonConvert.SerializeObject(cw);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpResponseMessage response = await _client.PostAsync("Clients", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }

        public static async void Update(ClientsWeb web)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");
            string json = JsonConvert.SerializeObject(web);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpResponseMessage response = await _client.PutAsync("Clients", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }

        public static async void Delete(int id)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");
            using( HttpResponseMessage message = await _client.DeleteAsync("Clients/"+ id))
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }


    }
}
