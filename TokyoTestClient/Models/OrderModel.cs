namespace TokyoTestClient;

/// <summary>
/// Заказ
/// </summary>
public class OrderModel
{
    /// <summary>
    /// ID заказа
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Текст заказа
    /// </summary>
    public required string OrderText { get; set; }
}