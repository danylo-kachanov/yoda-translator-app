using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Windows;
using YodaTranslatorApp.Properties;
using YodaTranslatorApp.Services;

namespace YodaTranslatorApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IYodaTranslatorService _translatorService;
        private string _translatedText;
        private bool _isTranslatingNow;

        public string TranslatedText
        {
            get { return this._translatedText; }
            set
            {
                if (this._translatedText != value)
                {
                    this._translatedText = value;
                    base.RaisePropertyChanged();
                }                
            }
        }

        public bool IsTranslatingNow
        {
            get { return this._isTranslatingNow; }
            set
            {
                if (this._isTranslatingNow != value)
                {
                    this._isTranslatingNow = value;
                    base.RaisePropertyChanged();
                }
            }
        }

        public RelayCommand<string> TranslateTextCommand { get; private set; }

        public MainViewModel()
        {
            this.TranslateTextCommand = new RelayCommand<string>(this.TranslateTextCommandExecute);
            this._translatorService = SimpleIoc.Default.GetInstance<IYodaTranslatorService>();
        }

        private async void TranslateTextCommandExecute(string text)
        {
            if (this._translatorService != null && !this.IsTranslatingNow)
            {
                this.IsTranslatingNow = true;

                var responseData = await this._translatorService.TranslateText(text);

                this.IsTranslatingNow = false;

                if (responseData.IsSuccessful)
                {
                    this.TranslatedText = responseData.Data;
                }
                else
                {
                    var errorText = string.Format(Resources.RequestError,responseData.ErrorMessage);
                    MessageBox.Show(errorText, Resources.MainTitle);
                }
            }
        }
    }
}