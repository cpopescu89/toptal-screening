using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using AutomationFramework.Framework.Extensions;

namespace AutomationFramework.PageObjects
{
    public class HomePage : BasePage

    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private int ReviewsNumber { get; set; }

        private IWebElement AccountButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("navbarAccount")));
        private IWebElement LoginButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("navbarLoginButton")));

        private IWebElement BasketButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[routerlink='/basket']")));

        private IWebElement ClosePopupDialogButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("close-dialog")));

        private IWebElement AcceptCookiesButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cc-dismiss")));

        private IWebElement ReviewTextField =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("mat-form-field textarea")));

        private IWebElement SubmitReviewButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("mat-dialog-actions #submitButton")));

        private IWebElement ExpandReviewsButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("mat-expansion-panel-header")));
        private IEnumerable<IWebElement> Comments =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(".comment")));

        private IEnumerable<IWebElement> AvailableProducts => Wait.Until(
            ExpectedConditions.PresenceOfAllElementsLocatedBy(
                By.XPath("//mat-card/div[1][not(contains(@class, 'ribbon-sold'))]//..//..//mat-card")));


        public void ClickAccountButton() => AccountButton.Click();
        public LoginPage ClickLoginButton()
        {
            LoginButton.Click();
            return new LoginPage(Driver);
        }

        public bool HasBasket() => BasketButton.Displayed;

        public void AcceptCookies()
        {
            ClosePopupDialogButton.Click();
            AcceptCookiesButton.Click();
        }

        public List<string> AddAvailableProductsToBasket(int numberOfProducts)
        {
            var productList = new List<string>();
            while (productList.Count < numberOfProducts)
            {
                var product = AvailableProducts.PickRandom();
                var itemName = product.FindElement(By.ClassName("item-name")).Text;
                if (productList.Contains(itemName)) continue;
                product.FindElement(By.CssSelector(".btn-basket")).Click();
                productList.Add(itemName);
                Notification.FindElement(By.TagName("button")).Click();
            }

            return productList;
        }

        public BasketPage GoToBasket()
        {
            BasketButton.Click();
            return new BasketPage(Driver);
        }

        public void OpenRandomProduct()
        {
            var product = AvailableProducts.PickRandom();
            product.FindElement(By.XPath(".//img")).Click();
        }

        public void AddReviewOfLength(string review)
        {
            ReviewTextField.Click();
            ReviewTextField.SendKeys(review);
            ReviewsNumber = GetReviewsNumber();
            SubmitReviewButton.Click();
        }

        private int GetReviewsNumber()
        {

            var text = ExpandReviewsButton.Text;
            var resultString = int.Parse(Regex.Match(text, @"\d+").Value);
            return resultString;
        }

        public bool ProductHasReview(string review)
        {
            //wait until review gets published. If it doesn't get published in 10 seconds, fail test
            var count = 0;
            while (GetReviewsNumber() <= ReviewsNumber)
            {
                Thread.Sleep(1000);
                count++;
                if (count == 10) return false;
            }

            ExpandReviewsButton.Click();
            return Wait.Until(ExpectedConditions.TextToBePresentInElement(Comments.Last(), review));
        }
    }
}
