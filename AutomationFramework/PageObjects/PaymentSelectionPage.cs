using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationFramework.PageObjects
{
    public class PaymentSelectionPage :BasePage
    {
        public PaymentSelectionPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AddNewCardButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector("div:nth-child(1) > div > mat-expansion-panel")));

        private IWebElement NameField =>
            Wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector(".mat-expanded mat-form-field:nth-child(1) input")));

        private IWebElement CardNumberField =>
            Wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector(".mat-expanded mat-form-field:nth-child(2) input")));

        private IWebElement CardExpiryMonthField => Wait.Until(
            ExpectedConditions.ElementIsVisible(By.CssSelector(".mat-expanded mat-form-field:nth-child(3) select")));

        private IWebElement CardExpiryYearField =>
            Wait.Until(ExpectedConditions.ElementIsVisible(
                By.CssSelector(".mat-expanded mat-form-field:nth-child(4) select")));

        private IWebElement SubmitCardButton => 
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submitButton")));

        private IWebElement ContinueButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".nextButton")));

        private IEnumerable<IWebElement> AvailableCards =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("mat-row")));

        public OrderSummaryPage ProceedToReviewOrder(bool addNewCard, int cardNumber = 0)
        {
            if (addNewCard) AddNewCard();
            AvailableCards.ElementAt(cardNumber).FindElement(By.CssSelector(".mat-radio-label")).Click();
            ContinueButton.Click();
            return new OrderSummaryPage(Driver);
        }

        private void AddNewCard()
        {
            AddNewCardButton.Click();
            NameField.SendKeys("dummy name");
            CardNumberField.SendKeys(new string('1', 16));
            var selectMonthElement = new SelectElement(CardExpiryMonthField);
            var selectYearElement = new SelectElement(CardExpiryYearField);
            selectMonthElement.SelectByIndex(1);
            selectYearElement.SelectByIndex(1);
            SubmitCardButton.Click();
        }
    }
}
