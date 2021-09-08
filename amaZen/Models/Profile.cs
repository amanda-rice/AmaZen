namespace amaZen.Models
{
  public class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
    public class WishlistProfileViewModel : Profile
    {
      public int WishlistId {get; set; }
    }
}