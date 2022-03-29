namespace ANUPayments.Models
{
    public enum Mode
    {
        Staging,
        Production
    }

    public class ApiConfiguration
    {
        public Mode Mode { get; set; }
        public string MerchantId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string XHeaderAuthorization { get; set; }
        public string ApiSecretKeyLive { get; set; }
        public string ApiSecretKeyStaging { get; set; }
        public string Company { get; set; }
        public string ApiSecretKey => Mode == Mode.Production ? ApiSecretKeyLive : ApiSecretKeyStaging;
    }
}