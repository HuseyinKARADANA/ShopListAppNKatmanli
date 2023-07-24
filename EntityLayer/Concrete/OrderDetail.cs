namespace EntityLayer.Concrete
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ItemDetailId { get; set; }

        public ItemDetail ItemDetail { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
