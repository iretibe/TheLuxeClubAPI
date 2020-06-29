using System.Collections.Generic;

namespace TheLuxe.Model.User
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
