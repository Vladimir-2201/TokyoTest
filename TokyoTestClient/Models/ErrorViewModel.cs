namespace TokyoTestClient.Models;

/// <summary>
/// Ошибка (стандартная модель)
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// ID запроса
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Отображать ID запроса
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}