namespace Deventure.Common.Response
{
    public static class ResponseFactory
    {
        public static Response ErrorReponse => CreateResponse(false, ResponseCode.ErrorAnErrorOccurred);
        public static Response InvalidInputResponse => CreateResponse(false, ResponseCode.ErrorInvalidInput);
        public static Response SuccessResponse => CreateResponse(true, ResponseCode.Success);
        //public static Response PartialSuccessResponse => CreateResponse(true, ResponseCode.SuccessPartial);

        public static Response CreateResponse(bool success, int responseCode)
        {
            return new Response(success, responseCode);
        }

        public static Response CreateResponse(bool success)
        {
            if (success)
            {
                return new Response(success, ResponseCode.Success);

            }

            return new Response(success, ResponseCode.Error);
        }

        public static Response FromObjectIsNotNull(object obj)
        {
            return obj != null ? SuccessResponse : ErrorReponse;
        }

        public static Response<T> FromObjectIsNotNullWithObject<T>(T obj)
            where T : class
        {
            return obj != null ? Success(obj) : Error<T>();
        }

        public static Response FromBool(bool result)
        {
            return result ? SuccessResponse : ErrorReponse;
        }

        public static Response<T> FromBool<T>(bool result)
            where T : class
        {
            return result ? Success<T>() : Error<T>();
        }

        public static Response Error()
        {
            return new Response(false, ResponseCode.ErrorAnErrorOccurred);
        }

        public static Response<T> Error<T>()
            where T : class
        {
            return new Response<T>(false, ResponseCode.ErrorAnErrorOccurred, null);
        }

        public static Response<T> Error<T>(T obj)
            where T : class
        {
            return new Response<T>(false, ResponseCode.ErrorAnErrorOccurred, obj);
        }

        public static Response Error(int errorCode)
        {
            return new Response(false, errorCode);
        }

        public static Response<T> Error<T>(int errorCode)
            where T : class
        {
            return new Response<T>(false, errorCode, null);
        }

        public static Response Success(int responseCode = ResponseCode.Success)
        {
            return new Response(true, responseCode);
        }

        public static Response<T> Success<T>(int responseCode)
            where T : class
        {
            return new Response<T>(true, responseCode, null);
        }

        public static Response<T> Success<T>(T data = null)
            where T : class
        {
            return new Response<T>(true, ResponseCode.Success, data);
        }

        public static Response<T> Success<T>(int statusCode, T data = null)
           where T : class
        {
            return new Response<T>(true, statusCode, data);
        }

        public static Response<T> CreateResponse<T>(bool success, int errorCode, T data = null)
            where T : class
        {
            return new Response<T>(success, errorCode, data);
        }

        public static bool InternetNotAvailable(Response response)
        {
            if (response == null)
            {
                return true;
            }

            return !response.Success && response.StatusCode.IsEqualToResponseCode(ResponseCode.ErrorNoInternet);
        }

        public static bool IsSuccessful(Response response)
        {
            return response != null && response.Success;
        }

        public static bool HasFailed(Response response)
        {
            return response == null || !response.Success;
        }
    }
}