using GalaSoft.MvvmLight.Ioc;
using System;
using System.Windows;
using YodaTranslatorApp.Services;

namespace YodaTranslatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SimpleIoc.Default.Register<IYodaTranslatorService, YodaTranslatorService>();
        }
    }
}
