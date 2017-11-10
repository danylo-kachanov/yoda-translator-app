using System;

namespace YodaTranslatorApp.Services
{
    public class ResponseData<T>
    {
        public T Data { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
    }
}
