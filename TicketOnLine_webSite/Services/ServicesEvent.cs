using Microsoft.AspNetCore.Http;
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
    public class ServicesEvent
    {
        public static async Task<List<EventWeb>> Get()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await _client.GetAsync("Event");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<EventWeb>>(json);
        }


        public static async Task<EventWeb>Get(int id)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await _client.GetAsync("Event/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<EventWeb>(json);
        }


        public static async void Post(EventWeb web)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");
            string json = JsonConvert.SerializeObject(web);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await _client.PostAsync("Event", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }

        public static async void Update(EventWeb web)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44399/api/");
            string json = JsonConvert.SerializeObject(web);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await _client.PutAsync("Event", content))
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
            using (HttpResponseMessage message = await _client.DeleteAsync("Event/" + id))
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}
