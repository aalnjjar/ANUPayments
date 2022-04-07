using System.Threading.Tasks;
using ANUPayments.Models;

namespace ANUPayments.Payments
{
    public interface IPaymentRequest
    {
        Task<GenericResponse<UPaymentResponses, UPaymentResponses>> Create(PaymentRequestModel requestModel);
    }
}