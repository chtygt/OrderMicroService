namespace Services.Shared.Models
{
    public class AuthenticationOptions
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
