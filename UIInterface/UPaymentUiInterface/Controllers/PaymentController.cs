using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANUPayments.Models;
using ANUPayments.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UPaymentUiInterface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public async Task<dynamic> Get([FromServices] IPaymentRequest paymentRequest)
        {
            var details = await paymentRequest.Create(new PaymentRequestModel()
            {
                Products = new List<PaymentRequestProductsModel>()
                {
                    new PaymentRequestProductsModel()
                    {
                        ProductName = "sku123",
                        ProductPrice = 10,
                        ProductQty = 2,
                        ProductTitle = "test 123"
                    }
                },
                Reference = "12355",
                CurrencyCode = "kwd",
                CustomerEmail = "aalnjjar32@hotmail.com",
                Whitelabled = 1,
                CustomerMobile = "55211461",
                ErrorUrl = "https://localhost:44390/payment/error",
                OrderId = "12346",
                PaymentGateway = "cc",
                SuccessUrl = "https://localhost:44390/payment/success",
                TotalPrice = 12,
                CustomerFName = "ahmed",
                NotifyURL = "https://localhost:44390/payment",
            });

            return details;
        }


        [HttpPost]
        public dynamic NotifyUrl([FromBody] UPaymentNotifyPayload payload)
        {
            return payload;
        }


        [HttpGet("success")]
        public dynamic Success([FromQuery] string PaymentID, [FromQuery] string Result,
            [FromQuery] string PostDate, [FromQuery] string Ref, [FromQuery] string TrackID,
            [FromQuery] string Auth, [FromQuery] string OrderID, [FromQuery] string payment_type,
            [FromQuery] string invoice_id, [FromQuery] string receipt_id, [FromQuery] string cust_ref)
        {
            return new
            {
                PaymentID,
                Result,
                PostDate,
                Ref,
                TrackID,
                Auth,
                OrderID,
                payment_type,
                invoice_id,
                receipt_id,
                cust_ref
            };
        }



        [HttpGet("error")]
        public dynamic Error([FromQuery] string PaymentID, [FromQuery] string Result,
          [FromQuery] string PostDate, [FromQuery] string Ref, [FromQuery] string TrackID,
          [FromQuery] string Auth, [FromQuery] string OrderID, [FromQuery] string payment_type,
          [FromQuery] string invoice_id, [FromQuery] string receipt_id, [FromQuery] string cust_ref)
        {
            return new
            {
                PaymentID,
                Result,
                PostDate,
                Ref,
                TrackID,
                Auth,
                OrderID,
                payment_type,
                invoice_id,
                receipt_id,
                cust_ref
            };
        }
    }
}