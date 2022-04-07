using System;
using System.Collections.Generic;
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


        public async Task<GenericResponse<UPaymentResponses, UPaymentResponses>> Create(PaymentRequestModel requestModel)
        {
            try
            {
                var request = GenerateRequest(requestModel);
                var apiResponse =
                    await _httpClientFactory.PostAsync<UPaymentResponses, UPaymentResponses>("", request);

                return apiResponse;
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
                CurrencyCode = requestModel.CurrencyCode.ToUpper(),
                success_url = requestModel.SuccessUrl,
                error_url = requestModel.ErrorUrl,
                test_mode = _apiConfiguration.Mode.IntValue(),
                CstFName = requestModel.CustomerFName,
                CstEmail = requestModel.CustomerEmail,
                CstMobile = requestModel.CustomerMobile,
                payment_gateway = requestModel.PaymentGateway,
                whitelabled = requestModel.Whitelabled,
                ProductTitle = requestModel.Products.Select(i => i.ProductTitle).ToList(),
                ProductName = requestModel.Products.Select(i => i.ProductName).ToList(),
                ProductPrice = requestModel.Products.Select(i => i.ProductPrice).ToList(),
                ProductQty = requestModel.Products.Select(i => i.ProductQty).ToList(),
                reference = requestModel.Reference,
                ExtraMerchantsData = requestModel.ExtraMerchantsData != null ? requestModel.ExtraMerchantsData.ToList() : new List<PaymentRequestExtraMerchantsDataModel>(),
                notifyURL = requestModel.NotifyURL
            };
        }
    }
}