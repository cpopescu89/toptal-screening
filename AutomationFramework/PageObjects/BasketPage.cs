using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class BasketPage : BasePage
    {
        public BasketPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement CheckoutButton => 
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("checkoutButton")));
        private IEnumerable<IWebElement> BasketContents =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-row")));

        public bool HasProducts(List<string> productsList) => productsList.All(product => BasketContents.Any(x => x.Text.ToLower().Contains(product.ToLower())));

        public AddressPage Checkout()
        {
            CheckoutButton.Click();
            return new AddressPage(Driver);
        }
    }
}
