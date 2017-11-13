using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using YodaTranslatorApp.Helpers;
using YodaTranslatorApp.Properties;

namespace YodaTranslatorApp.Services
{
    public class YodaTranslatorService : IYodaTranslatorService
    {
        private readonly string _constantYodaApiKey = "UlpDWta9PQmshXccYnj9o9uwfTf0p1Fvs7fjsn1Ljw4CLW9EIS";

        public async Task<ResponseData<string>> TranslateText(string originalText)
        {
            var responseData = new ResponseData<string>();

            await Task.Run(async () =>
            {
                var requestUrl = string.Format(Constants.YodaTranslateRequestPattern, Constants.YodaTranslationServiceMainUrl, Uri.EscapeDataString(originalText));

                if (InternetAvailability.IsInternetAvailable())
                {
                    var request = (HttpWebRequest)WebRequest.Create(requestUrl);
                    request.Method = Constants.GetRequestMethod;
                    request.Headers.Add("X-Mashape-Key", this._constantYodaApiKey);
                    request.Accept= "text/plain";

                    try
                    {
                        var response = await request.GetResponseAsync();
                        var responseStream = response?.GetResponseStream();
                        if (responseStream != null)
                        {
                            var responseContent = new StreamReader(responseStream).ReadToEnd();
                            responseData.Data = responseContent;
                            responseData.IsSuccessful = true;
                            response.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        responseData.Exception = ex;
                        responseData.ErrorMessage = ex.Message;
                    }
                }
                else
                {
                    responseData.ErrorMessage = Resources.InternetConnectionError;
                }
            });
            return responseData;
        }

        private class InternetAvailability
        {
            [DllImport("wininet.dll")]
            private extern static bool InternetGetConnectedState(out int description, int reservedValue);

            public static bool IsInternetAvailable()
            {
                int description;
                return InternetGetConnectedState(out description, 0);
            }
        }
    }
}
