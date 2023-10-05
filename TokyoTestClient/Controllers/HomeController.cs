using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TokyoTestClient.Models;

namespace TokyoTestClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using HttpResponseMessage response = await client.GetAsync("http://localhost:5001/api/Orders");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<List<OrderModel>>(jsonResponse)!;
            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            JsonContent content = JsonContent.Create(order);
            using var response = await client.PostAsync("http://localhost:5001/api/Orders", content);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string url = "http://localhost:5001/api/Orders/" + id.ToString();
            using var response = await client.DeleteAsync(url);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}