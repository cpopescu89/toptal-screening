using System;
using OpenQA.Selenium;

namespace AutomationFramework.Framework
{
    public static class CustomExpectedConditions
    {
        public static Func<IWebDriver, bool> ElementHasText(By selector)
        {
            return driver =>
            {
                try
                {
                    var element = driver.FindElement(selector);
                    return !string.IsNullOrWhiteSpace(element.Text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        //public static Func<IWebDriver, bool> ClassIsGone(By selector, string className)
        //{
        //    return driver =>
        //    {
        //        try
        //        {
        //            var element = driver.FindElement(selector);
        //            return !element.HasCssClass(className);
        //        }
        //        catch (StaleElementReferenceException)
        //        {
        //            return false;
        //        }
        //    };
        //}

        public static Func<IWebDriver, bool> TextToBePresentInElementLocated(By locator, string text, Func<string, string> transformFunc)
        {
            return (Func<IWebDriver, bool>)(driver =>
            {
                try
                {
                    var elementText = driver.FindElement(locator).Text;
                    return transformFunc(elementText).Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });
        }



    }

}
