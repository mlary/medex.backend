
namespace Medex.Data.Infrastructure
{
    public class AuthConfiguration
    {
        public string DomainAddress { get; set; }
        public string Domain { get; set; }
        public string SearchBase { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string SystemUserLogin { get; set; }
        public string SystemUserPassword { get; set; }
    }
}