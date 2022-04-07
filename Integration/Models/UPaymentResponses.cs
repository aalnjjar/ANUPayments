using Newtonsoft.Json;

namespace ANUPayments.Models
{
    public class UPaymentResponses
    {
        public string Status { get; set; }
        public string PaymentUrl { get; set; }
        [JsonProperty("error_msg")] public string ErrorMsg { get; set; }
        [JsonProperty("error_code")] public string ErrorCode { get; set; }
    }
}