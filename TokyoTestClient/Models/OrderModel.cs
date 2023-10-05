namespace TokyoTestClient
{
    public class OrderModel
    {
        public int Id { get; set; }

        //required чтоб убрать предупреждение CS8618, также можно было использовать атрибут [Required] или сделать тип nullable
        public required string OrderText { get; set; }
    }
}
