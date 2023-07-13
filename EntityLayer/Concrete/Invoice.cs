namespace ShoppingListApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public DateTime Date { get; set; }

        public int FicheNo { get; set; }

        public decimal MyProperty { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
