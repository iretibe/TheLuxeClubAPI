namespace TheLuxe.Mobile.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string imageUrl { get; set; }
        public decimal price { get; set; }
        public string isPopularProduct { get; set; }
        public int categoryId { get; set; }
        public string imageArray { get; set; }

        public string FullImageUrl => AppSettings.ApiUrl + imageUrl;
    }
}
