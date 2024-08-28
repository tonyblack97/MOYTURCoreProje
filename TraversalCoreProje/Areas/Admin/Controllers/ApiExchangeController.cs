using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    public class ApiExchangeController : Controller
    {
        [Area("Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeViewModel> bookingExchangeViewModel = new List<BookingExchangeViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=AED"),
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

                bookingExchangeViewModel = JsonConvert.DeserializeObject<List<BookingExchangeViewModel>>(body);
                return View(bookingExchangeViewModel);
            }
        }
    }
}

