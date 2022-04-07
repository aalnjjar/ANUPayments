using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ANUPayments.Models
{
    public class PaymentRequestModel
    {
        /// <summary>
        /// your system order id
        /// unique ID
        /// Store in your database 
        /// It will be used for future reference 
        /// Use a strong hashing with time
        /// Min 15, Max 35 characters
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// Payable amount (max 3 decimal points)
        /// </summary>
        [JsonProperty("total_price")]
        public float TotalPrice { get; set; }

        /// <summary>
        /// currency code 
        /// </summary>
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }


        /// <summary>
        /// URL to redirect the user on successful transaction
        /// </summary>
        [JsonProperty("success_url")]
        public string SuccessUrl { get; set; }


        /// <summary>
        /// URL to redirect the user on unsuccessful transaction
        /// </summary>
        [JsonProperty("error_url")]
        public string ErrorUrl { get; set; }

        /// <summary>
        /// Webhook notification - like IPN 
        /// (Instant Payment Notification)
        /// </summary>
        [JsonProperty("notifyURL")]
        public string NotifyURL { get; set; }

        /// <summary>
        /// 1 for test mode
        /// 0 for production
        /// </summary>
        [JsonProperty("test_mode")]
        internal int TestMode { get; set; }

        /// <summary>
        /// Customer Full Name
        /// </summary>
        [JsonProperty("CstFName")]
        public string CustomerFName { get; set; }

        /// <summary>
        /// Customer Email Address
        /// </summary>
        [JsonProperty("CstEmail")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Customer Mobile Number
        /// </summary>
        [JsonProperty("CstMobile")]
        public string CustomerMobile { get; set; }

        /// <summary>
        /// Knet for Knet transaction 
        /// cc for Credit Card TransactionTransaction 
        /// (Only for whitelabled API)
        /// </summary>
        [JsonProperty("payment_gateway")]
        public string PaymentGateway { get; set; }

        /// <summary>
        /// Merchant Order ID or Reference number
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// 1 = true (must be enabled by admin)
        /// 0 = false
        /// </summary>
        [JsonProperty("whitelabled")]
        public int Whitelabled { get; set; }


        /// <summary>
        /// list of products 
        /// </summary>
        public List<PaymentRequestProductsModel> Products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PaymentRequestExtraMerchantsDataModel> ExtraMerchantsData { get; set; }
    }
}

public class PaymentRequestProductsModel
{
    /// <summary>
    /// product title description
    /// </summary>
    public string ProductTitle { get; set; }

    /// <summary>
    /// product SKU
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// product price
    /// </summary>
    public float ProductPrice { get; set; }

    /// <summary>
    /// Product qty
    /// </summary>
    public float ProductQty { get; set; }
}

public abstract class PaymentRequestExtraMerchantsDataModel
{
    /// <summary>
    /// amounts: Amount that “payer” is paying to single or different vendors
    /// </summary>
    [JsonProperty("amounts")]
    public float[] Amounts { get; set; }

    /// <summary>
    /// charges: Merchant’s charge rate for his vendor for KNET. 
    /// </summary>
    [JsonProperty("charges")]
    public float[] Charges { get; set; }


    /// <summary>
    /// chargeType: Charge rate type (Fixed or Percentage) for KNET
    /// </summary>
    [JsonProperty("chargeType")]
    public string[] ChargeType { get; set; }

    /// <summary>
    /// cc_charges: Merchant’s charge rate for his vendor for CreditCard. 
    /// </summary>
    [JsonProperty("cc_charges")]
    public float[] CreditCardCharges { get; set; }

    /// <summary>
    /// cc_chargeType: cc Charge rate type (Fixed or Percentage) for CreditCard.
    /// </summary>
    [JsonProperty("cc_chargeType")]
    public string[] CreditCardChargesType { get; set; }

    /// <summary>
    /// ibans: IBAN Numbers of difference vendors
    /// </summary>
    [JsonProperty("ibans")]
    public string[] Ibans { get; set; }
}