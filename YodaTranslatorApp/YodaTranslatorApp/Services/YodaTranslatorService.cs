using System.Threading.Tasks;
using YodaTranslatorApp.Helpers;

namespace YodaTranslatorApp.Services
{
    public class YodaTranslatorService : IYodaTranslatorService
    {
        public async Task<string> TranslateText(string originalText)
        {
            var url = string.Format(Constants.YodaTranslateRequestPattern, Constants.YodaTranslationServiceMainUrl, originalText);

            await Task.Delay(1000);

            return url;
        }
    }
}
