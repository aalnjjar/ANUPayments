using System;
using System.Linq;
using System.Threading.Tasks;
using ANUPayments.Helpers;
using ANUPayments.Models;

namespace ANUPayments.Payments
{
    public class PaymentRequest : IPaymentRequest
    {
        private readonly ApiConfiguration _apiConfiguration;
        private readonly HttpClientFactory _httpClientFactory;

        public PaymentRequest(ApiConfiguration configuration)
        {
            _apiConfiguration = configuration;
            _httpClientFactory = new HttpClientFactory(configuration.XHeaderAuthorization, configuration.Mode);
        }


        public async Task<GenericResponse<object, object>> Create(PaymentRequestModel requestModel)
        {
            try
            {
                var request = GenerateRequest(requestModel);
                var apiResponse =
                    await _httpClientFactory.PostAsync<object, object>("charges", request);

                return new GenericResponse<object, object>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private dynamic GenerateRequest(PaymentRequestModel requestModel)
        {
            return new
            {
                merchant_id = _apiConfiguration.MerchantId,
                username = _apiConfiguration.UserName,
                password = _apiConfiguration.Password,
                api_key = _apiConfiguration.ApiSecretKey,
                order_id = requestModel.OrderId,
                total_price = requestModel.TotalPrice,
                CurrencyCode = requestModel.CurrencyCode,
                success_url = requestModel.SuccessUrl,
                error_url = requestModel.ErrorUrl,
                test_mode = _apiConfiguration.Mode.IntValue(),
                CstFName = requestModel.CustomerFName,
                CstEmail = requestModel.CustomerEmail,
                CstMobile = requestModel.CustomerMobile,
                payment_gateway = requestModel.PaymentGateway,
                whitelabled = requestModel.Whitelabled,
                ProductTitle = requestModel.Products.Select(i => i.ProductTitle).ToArray(),
                ProductName = requestModel.Products.Select(i => i.ProductName).ToArray(),
                ProductPrice = requestModel.Products.Select(i => i.ProductPrice).ToArray(),
                ProductQty = requestModel.Products.Select(i => i.ProductQty).ToArray(),
                reference = requestModel.Reference,
                ExtraMerchantsData = requestModel.ExtraMerchantsData.ToArray(),
                notifyURL = requestModel.NotifyURL
            };
        }
    }
}