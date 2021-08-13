using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class OrderSummaryPage : BasePage
    {
        public OrderSummaryPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement PlaceOrderAndPay =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".btn-pay")));

        private IEnumerable<IWebElement> ProductNames =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("app-purchase-basket mat-cell:nth-child(2)")));

        public bool HasProducts(List<string> productsList) => productsList.All(product => ProductNames.Any(x => x.Text.ToLower().Contains(product.ToLower())));

        public void PlaceOrder() => PlaceOrderAndPay.Click();
    }
}
