namespace TokyoTestServer
{
    public class Order
    {
        public int Id { get; set; }

        //required чтоб убрать предупреждение CS8618, также можно было, например, сделать тип nullable
        public required string OrderText { get; set; }
    }
}