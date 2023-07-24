namespace EntityLayer.Concrete
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; }

        public int ItemDetailId { get; set; }

        public ItemDetail ItemDetail { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }
    }
}
