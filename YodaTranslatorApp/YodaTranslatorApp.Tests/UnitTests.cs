using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace YodaTranslatorApp.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private const string _relativeAppPath = @"..\..\..\YodaTranslatorApp\bin\Debug\YodaTranslatorApp.exe";

        private const string _mainWindowTitle = "Yoda Translator";

        private const int _maxTimeForTranslationProcess = 6;

        private const string _testTextForTranslating = "This is test text for Yoda translating. I hope, that test will finishing successful.";

        [Test]
        public void CheckCorrectTranslationProcess()
        {
            var appPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _relativeAppPath);
            var application = Application.Launch(appPath);

            var window = application.GetWindow(_mainWindowTitle);
            
            var textBox = window.Get<TextBox>(SearchCriteria.ByAutomationId("TextBoxWithOriginalTextId"));
            textBox.Text = _testTextForTranslating;

            var button = window.Get<Button>(SearchCriteria.ByAutomationId("TranslateButtonId"));
            button.Click();

            var textBox2 = window.Get<TextBox>(SearchCriteria.ByAutomationId("TextBoxWithTranslatedTextId"));

            window.WaitTill(new TestStack.White.UIItems.WindowItems.Window.WaitTillDelegate(() => !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)), TimeSpan.FromSeconds(_maxTimeForTranslationProcess));

            application.Kill();
        }

        [Test]
        public void CheckCorrectTranslationButtonBehavior()
        {
            var appPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _relativeAppPath);
            var application = Application.Launch(appPath);

            var window = application.GetWindow("Yoda Translator");

            var textBox = window.Get<TextBox>(SearchCriteria.ByAutomationId("TextBoxWithOriginalTextId"));
            var button = window.Get<Button>(SearchCriteria.ByAutomationId("TranslateButtonId"));

            Assert.AreEqual(string.IsNullOrEmpty(textBox.Text), !button.Enabled);

            textBox.Text = _testTextForTranslating;

            Assert.AreEqual(string.IsNullOrEmpty(textBox.Text), !button.Enabled);

            application.Kill();
        }
    }
}
