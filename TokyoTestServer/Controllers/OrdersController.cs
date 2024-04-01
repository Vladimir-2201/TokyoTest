using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TokyoTestServer.Data;
using TokyoTestServer.Models;

namespace TokyoTestServer.Controllers;

/// <summary>
/// Контроллер заказов
/// </summary>
/// <remarks>
/// Инициализирует экземпляр класса <see cref="OrdersController"/>
/// </remarks>
/// <param name="context">Контекст базы данных</param>
[Route("api/[controller]")]
[ApiController]
public class OrdersController(TokyoTestDBContext context) : ControllerBase
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    private readonly TokyoTestDBContext _context = context;

    /// <summary>
    /// Получение списка заказов
    /// </summary>
    /// <returns>Список заказов</returns>
    /// <remarks>GET: api/Orders</remarks>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }

        return await _context.Orders.ToListAsync();
    }

    /// <summary>
    /// Coздание заказа
    /// </summary>
    /// <param name="order">Заказ</param>
    /// <returns>Status Code 201 (Created) или Problem</returns>
    /// <remarks>POST: api/Orders</remarks>
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        if (_context.Orders == null)
        {
            return Problem("Не удалось создать новый заказ");
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    /// <summary>
    /// Удаление заказа
    /// </summary>
    /// <param name="id">ID заказа</param>
    /// <returns>Status Code 204 (No Content) или 404 (Not Found)</returns>
    /// <remarks>DELETE: api/Orders/5</remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }

        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}