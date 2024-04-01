using Microsoft.EntityFrameworkCore;
using TokyoTestServer.Models;

namespace TokyoTestServer.Data;

/// <summary>
/// Контекст базы данных
/// </summary>
public class TokyoTestDBContext : DbContext
{
    /// <summary>
    /// Инициализирует экземпляр класса <see cref="TokyoTestDBContext"/>
    /// </summary>
    /// <param name="options">Параметры</param>
    public TokyoTestDBContext(DbContextOptions<TokyoTestDBContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    /// <summary>
    /// Таблица "Orders" (Заказы)
    /// </summary>
    public DbSet<Order> Orders { get; set; } = default!;
}
