using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TokyoTestClient.Models;

namespace TokyoTestClient.Controllers;

/// <summary>
/// Контроллер заказов
/// </summary>
public class OrderController : Controller
{
    /// <summary>
    /// Логгер
    /// </summary>
    private readonly ILogger<OrderController> _logger;
    /// <summary>
    /// HTTP-клиент
    /// </summary>
    private static readonly HttpClient client = new();
    /// <summary>
    /// Адрес сервера
    /// </summary>
    private readonly string host = "http://localhost:5001/";

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="OrderController"/>
    /// </summary>
    /// <param name="logger">Логгер</param>
    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Получение/отображение заказов
    /// </summary>
    /// <returns>Страница с заказами</returns>
    public async Task<IActionResult> Index()
    {
        using HttpResponseMessage response = await client.GetAsync($"{host}api/Orders");
        string jsonResponse = await response.Content.ReadAsStringAsync();
        List<OrderModel> order = JsonConvert.DeserializeObject<List<OrderModel>>(jsonResponse)!;
        return View(order);
    }

    /// <summary>
    /// Создание нового заказа 
    /// </summary>
    /// <returns>Пустая страница создания нового заказа</returns>
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Создание нового заказа 
    /// </summary>
    /// <param name="order">Заказ</param>
    /// <returns>Страница с заказами</returns>
    [HttpPost]
    public async Task<IActionResult> Create(OrderModel order)
    {
        JsonContent content = JsonContent.Create(order);
        using HttpResponseMessage response = await client.PostAsync($"{host}api/Orders", content);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Удаление заказа
    /// </summary>
    /// <param name="id">ID заказа</param>
    /// <returns>Страница с заказами</returns>
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        using HttpResponseMessage response = await client.DeleteAsync($"{host}api/Orders/{id}");
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Ошибка
    /// </summary>
    /// <returns>Стандартная страница ошибки</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}