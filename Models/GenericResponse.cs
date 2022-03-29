namespace ANUPayments.Models
{
    public class GenericResponse<T, TU>
    {
        public GenericResponse()
        {
        }

        public GenericResponse(string jsonResponse, T successResponse, TU failureResponse)
        {
            IsSuccess = failureResponse == null;
            JsonResponse = jsonResponse;
            SuccessResponse = successResponse;
            FailureResponse = failureResponse;
        }

        public bool IsSuccess { get; set; }
        public string JsonResponse { get; set; }
        public T SuccessResponse { get; set; }
        public TU FailureResponse { get; set; }
    }
}