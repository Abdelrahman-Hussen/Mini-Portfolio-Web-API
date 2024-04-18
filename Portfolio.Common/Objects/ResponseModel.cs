namespace Portfolio.Common.Objects
{
    public class ResponseModel<T>
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ResponseModel<T> Success(T? data = default(T), string? message = null)
        {
            return new ResponseModel<T>
            {
                Data = data,
                Ok = true,
                Message = message ?? Portfolio.Common.Resources.Message.Success_General,
            };
        }

        public static ResponseModel<T> Error(string message = null, T? data = default(T))
        {
            return new ResponseModel<T>
            {
                Data = data,
                Ok = false,
                Message = message ?? Portfolio.Common.Resources.Message.Error_General
            };
        }
    }
}
