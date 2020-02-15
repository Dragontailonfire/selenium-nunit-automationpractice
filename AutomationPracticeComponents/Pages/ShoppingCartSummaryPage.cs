using FluentAssertions;
using OpenQA.Selenium;

namespace AutomationPracticeComponents.Pages
{
    public class ShoppingCartSummaryPage
    {
        IWebDriver _webDriver;
        public ShoppingCartSummaryPage(IWebDriver webDriver) => _webDriver = webDriver;

        public void VerifyPageIsDisplayed()
        {
            By identifier = By.Id("cart_title");
            IWebElement element = _webDriver.FindElement(identifier);
        }

        public void VerifyProductDetails(string name, string size, string quantity)
        {
            By identifierName = By.XPath("(//p[@class='product-name'])[2]");
            IWebElement elementName = _webDriver.FindElement(identifierName);
            By identifierSize = By.XPath("(//*[text()[contains(.,'Size')]])[2]");
            IWebElement elementSize = _webDriver.FindElement(identifierSize);

            //Quantity compared from element identification itself
            By identifierQuantity = By.XPath("//*[@class='cart_quantity_input form-control grey' and @value='" + quantity + "']");
            IWebElement elementQuantity = _webDriver.FindElement(identifierQuantity);

            //Take the entire text and take substring to get size and comapre
            string sizeText = elementSize.GetAttribute("innerText");
            int position = sizeText.LastIndexOf("Size : ");
            sizeText.Substring(position + "Size : ".Length).Trim().Should().Be(size);

            //Comapre name
            string nameText = elementName.GetAttribute("innerText").Trim();
            nameText.Should().Be(name);
        }
    }
}
