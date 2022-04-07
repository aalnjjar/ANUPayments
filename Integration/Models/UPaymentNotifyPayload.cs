using System;
using Newtonsoft.Json;

namespace ANUPayments.Models
{
    public class UPaymentNotifyPayload
    {
        [JsonProperty("PaymentID")] public string PaymentId { get; set; }
        [JsonProperty("Result")] public string Result { get; set; }
        [JsonProperty("PostDate")] public DateTime PostDate { get; set; }
        [JsonProperty("Ref")] public string Ref { get; set; }
        [JsonProperty("TrackID")] public string TrackId { get; set; }
        [JsonProperty("Auth")] public string Auth { get; set; }
        [JsonProperty("OrderID")] public string OrderId { get; set; }
        [JsonProperty("payment_type")] public string PaymentType { get; set; }
        [JsonProperty("invoice_id")] public string InvoiceId { get; set; }
        [JsonProperty("receipt_id")] public string ReceiptId { get; set; }
        [JsonProperty("cust_ref")] public string CustomerRef { get; set; }
    }
}