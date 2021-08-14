using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class DeliveryMethodPage :BasePage
    {
        public DeliveryMethodPage(IWebDriver driver) : base(driver)
        {
        }

        private IEnumerable<IWebElement> DeliveryMethods =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-row")));

        private IWebElement ContinueButton => 
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[aria-label='Proceed to delivery method selection']")));

        public PaymentSelectionPage SelectDeliver(int deliveryNumber)
        {
            DeliveryMethods.ElementAt(deliveryNumber).Click();
            ContinueButton.Click();
            return new PaymentSelectionPage(Driver);
        }
    }
}
