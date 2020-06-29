namespace TheLuxe.Mobile.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }

        public string FullImageUrl => AppSettings.ApiUrl + imageUrl;
    }
}
