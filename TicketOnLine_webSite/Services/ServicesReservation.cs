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
    public class ServicesReservation
    {
        public static async Task<List<ReservationWeb>> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await client.GetAsync("Reservation");
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<ReservationWeb>>(json);
        }

        public static async Task<ReservationWeb> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage message = await client.GetAsync("Reservation/" + id);
            string json = message.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ReservationWeb>(json);
        }


        public static async void Post(ReservationWeb w)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");

            string json = JsonConvert.SerializeObject(w);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await client.PostAsync("Reservation", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
            
        }
    }
}
