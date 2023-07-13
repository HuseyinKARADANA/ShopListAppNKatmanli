namespace EntityLayer.Concrete
{
    public class Item
    {
        public int Id { get; set; }

        public int ItemCode { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int FavoriteCount { get; set; }



        public List<FavoriteItemUser> FavoriteItemUsers { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
