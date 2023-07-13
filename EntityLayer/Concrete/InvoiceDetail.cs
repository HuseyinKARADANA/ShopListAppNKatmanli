namespace ShoppingListApp.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
    }
}
