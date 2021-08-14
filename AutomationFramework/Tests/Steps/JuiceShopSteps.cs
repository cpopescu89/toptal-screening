using System;
using System.Collections.Generic;
using AutomationFramework.Framework;
using AutomationFramework.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationFramework.Tests.Steps
{
    [Binding, Scope(Feature = "JuiceShop")]
    public class JuiceShopSteps
    {
        private readonly Navigator _navigator;
        private HomePage _homePage;
        private RegisterPage _registerPage;
        private LoginPage _loginPage;
        private BasketPage _basketPage;
        private AddressPage _addressPage;
        private DeliveryMethodPage _deliveryMethodPage;
        private PaymentSelectionPage _paymentSelectionPage;
        private OrderSummaryPage _orderSummaryPage;
        private ProfilePage _profilePage;
        private readonly string _email = $"{Guid.NewGuid()}@mail.com";
        private readonly string _password = $"{Guid.NewGuid()}"[..20];
        private List<string> _productsList = new List<string>();
        private string _username;
        private string _review;
        public JuiceShopSteps(Navigator navigator)
        {
            _navigator = navigator;
        }

        [Given(@"I register")]
        public void GivenIRegister()
        {
            _homePage = _navigator.GoTo<HomePage>(AppSettings.GetHomepage());
            _homePage.AcceptCookies();
            _homePage.ClickAccountButton();
            _loginPage = _homePage.ClickLoginButton();
            _registerPage = _loginPage.ClickRegisterButton();
            _registerPage.Register(_email, _password);
            Assert.True(_loginPage.HasRegistrationConfirmationPopup());
        }

        [Given(@"I Log in")]
        public void GivenILogIn()
        {
            _loginPage.LoginWithCredentials(_email, _password);
            Assert.True(_homePage.HasBasket());
        }

        [When(@"I add (.*) products to the basket")]
        public void WhenIAddProductsOtTheBasket(int numberOfProducts)
        {
            _productsList = _homePage.AddAvailableProductsToBasket(numberOfProducts);
        }

        [When(@"I checkout the purchased items")]
        public void WhenICheckoutThePurchasedItems()
        {
            _basketPage = _homePage.GoToBasket();
            Assert.True(_basketPage.HasProducts(_productsList));
            _addressPage = _basketPage.Checkout();
            _deliveryMethodPage = _addressPage.ProceedToCheckout(true);
        }

        [Then(@"I order them successfully using delivery option ""(.*)""")]
        public void ThenIOrderThemSuccessfullyUsingDeliveryOption(int deliveryNumber)
        {
            _paymentSelectionPage = _deliveryMethodPage.SelectDeliver(deliveryNumber);
            _orderSummaryPage = _paymentSelectionPage.ProceedToReviewOrder(true);
            Assert.True(_orderSummaryPage.HasProducts(_productsList));
            _orderSummaryPage.PlaceOrder();
        }


        [When(@"I go to the Profile page")]
        public void WhenIGoToTheProfilePage()
        {
            _profilePage = _navigator.GoTo<ProfilePage>(AppSettings.GetProfilePage());
        }

        [Then(@"I can change my username to ""(.*)""")]
        public void ThenICanChangeMyUsernameTo(string username)
        {
            _username = username;
            _profilePage.ChangeUsername(username);
        }


        [Then(@"my username is displayed on my profile page")]
        public void ThenMyUsernameIsDisplayedOnMyProfilePage()
        {
            Assert.True(_profilePage.HasUpdatedUsername(_username));
        }


        [Then(@"I can link an image ""(.*)""")]
        public void ThenICanLinkAnImage(string imageLink)
        {
            _profilePage.LinkImage(imageLink);
        }


        [When(@"I click a product")]
        public void WhenIClickAProduct()
        {
            _homePage.OpenRandomProduct();
        }

        [Then(@"I can leave a review of (.*) characters")]
        public void ThenICanLeaveAReviewOfCharacters(int length)
        {
            _review = new string('a', length);
            _homePage.AddReviewOfLength(_review);
        }

        [Then(@"my review is published")]
        public void ThenMyReviewIsPublished()
        {
            Assert.True(_homePage.ProductHasReview(_review));
        }


    }
}
