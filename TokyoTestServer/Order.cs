using TokyoTestServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace TokyoTestServer
{
    public class Order
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
