using System.Threading.Tasks;

namespace YodaTranslatorApp.Services
{ 
    public interface IYodaTranslatorService
    {
        Task<ResponseData<string>> TranslateText(string originalText);
    }
}
