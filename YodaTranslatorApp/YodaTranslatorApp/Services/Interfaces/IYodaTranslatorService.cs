using System.Threading.Tasks;

namespace YodaTranslatorApp.Services
{ 
    public interface IYodaTranslatorService
    {
        Task<string> TranslateText(string originalText);
    }
}
