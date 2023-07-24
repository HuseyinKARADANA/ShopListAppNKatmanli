namespace EntityLayer.Concrete
{
    public class ItemDetail
    {
        public int Id { get; set; }



        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int CategoryDetailId { get; set; }

        public int FeatureId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int FavoriteCount { get; set; }



        public List<OrderDetail> OrderDetails { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }

        public List<FavoriteItemUser> FavoriteItemUsers { get; set; }
    }
}
