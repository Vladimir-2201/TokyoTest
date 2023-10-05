using System.ComponentModel.DataAnnotations;

namespace TokyoTestClient
{
    public class OrderModel
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
    }
}
