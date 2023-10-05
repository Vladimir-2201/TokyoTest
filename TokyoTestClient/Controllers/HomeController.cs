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
        private readonly string host = "http://localhost:5001/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using HttpResponseMessage response = await client.GetAsync($"{host}api/Orders");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<OrderModel> order = JsonConvert.DeserializeObject<List<OrderModel>>(jsonResponse)!;
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
            using HttpResponseMessage response = await client.PostAsync($"{host}api/Orders", content);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using HttpResponseMessage response = await client.DeleteAsync($"{host}api/Orders/{id}");
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}