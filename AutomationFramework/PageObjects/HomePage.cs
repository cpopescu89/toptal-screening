using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework.Extensions;

namespace AutomationFramework.PageObjects
{
    public class HomePage : BasePage

    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AccountButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("navbarAccount")));
        private IWebElement LoginButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("navbarLoginButton")));

        private IWebElement BasketButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[routerlink='/basket']")));

        private IWebElement ClosePopupDialogButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("close-dialog")));

        private IWebElement AcceptCookiesButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".cc-dismiss")));

        private IReadOnlyCollection<IWebElement> AllProducts =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("mat-grid-tile")));

        private IReadOnlyCollection<IWebElement> AvailableProducts => Wait.Until(
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

        public void LogInExistingUser()
        {
            ClickAccountButton();
            var loginPage = ClickLoginButton();
            loginPage.LoginWithCredentials(AppSettings.GetUsername(), AppSettings.GetPassword());
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
    }
}
