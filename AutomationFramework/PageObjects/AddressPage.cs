using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class AddressPage : BasePage
    {

        public AddressPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AddNewAddressButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[routerlink='/address/create']")));
        private IWebElement CountryField => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field:nth-child(1) input:not([autocapitalize='none'])")));
        private IWebElement NameField => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field:nth-child(2) input")));
        private IWebElement MobileNumberField => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field:nth-child(3) input")));
        private IWebElement ZipCodeField => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field:nth-child(4) input")));
        private IWebElement CityField => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field:nth-child(6) input")));
        private IWebElement StateField => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field:nth-child(7) input")));
        private IWebElement AddressField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("address")));
        private IWebElement SubmitButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submitButton")));
        private IWebElement ContinueButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[aria-label='Proceed to payment selection']")));

        private IEnumerable<IWebElement> AddressList =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-row")));

        private void AddNewAddress()
        {
            AddNewAddressButton.Click();
            CountryField.SendKeys("Country");
            NameField.SendKeys("Name");
            MobileNumberField.SendKeys("111111111");
            ZipCodeField.SendKeys("333333");
            AddressField.SendKeys(Guid.NewGuid().ToString());
            CityField.SendKeys("City");
            StateField.SendKeys("state");
            SubmitButton.Click();
        }

        public DeliveryMethodPage ProceedToCheckout(bool addNewAddress, int address=0)
        {
            if (addNewAddress) AddNewAddress();
            AddressList.ElementAt(address).Click();
            ContinueButton.Click();
            return new DeliveryMethodPage(Driver);
        }
    }
}
