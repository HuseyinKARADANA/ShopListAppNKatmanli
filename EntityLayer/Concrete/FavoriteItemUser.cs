namespace EntityLayer.Concrete
{
    public class FavoriteItemUser
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ItemDetailId { get; set; }

        public ItemDetail ItemDetail { get; set; }
    }
}
