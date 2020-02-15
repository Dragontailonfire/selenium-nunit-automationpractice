using OpenQA.Selenium;

namespace AutomationPracticeComponents.Pages
{
    public class HomePage
    {
        IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateToPage(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
        }

        public void ClickMenuItem(string item)
        {
            By identifier = By.LinkText(item);
            IWebElement element = _webDriver.FindElement(identifier);
            element.Click();
        }
    }
}
