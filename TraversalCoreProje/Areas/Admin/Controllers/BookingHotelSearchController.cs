﻿using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // HTTP client oluştur
            var client = new HttpClient();

            // HTTP isteği oluştur
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?dest_id=-1456928&order_by=popularity&checkout_date=2025-01-19&children_number=2&filter_by_currency=USD&locale=en-gb&dest_type=city&checkin_date=2025-01-18&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&include_adjacency=true&page_number=0&adults_number=2&room_number=1&units=metric"),
                Headers =
                {
                    { "x-rapidapi-key", "f552743653mshd93009f39e14fffp1421d5jsn234ee1eed209" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };

            // HTTP isteğini gönder ve yanıtı işle
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // JSON verisini BookingHotelSearchViewModel nesnesine deserial et
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);

                // Sonuçları View'a gönder
                return View(values.results); // results dizisini View'a geçiriyoruz
            }
        }

        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View(); 
        }


        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-us&name={p}"),
                Headers =
    {
        { "x-rapidapi-key", "f552743653mshd93009f39e14fffp1421d5jsn234ee1eed209" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }
}
