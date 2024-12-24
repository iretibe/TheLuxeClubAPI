namespace TheLuxe.Mobile.Models
{
    public class PopularProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }

        public string FullImageUrl => AppSettings.ApiUrl + imageUrl;
    }
}
