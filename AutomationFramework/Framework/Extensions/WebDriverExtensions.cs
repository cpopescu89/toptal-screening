using OpenQA.Selenium;

namespace AutomationFramework.Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void ScrollToElement(this IWebDriver driver, IWebElement element) =>
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);

        public static bool ElementExists(this IWebDriver driver, By by)
        {
            try { driver.FindElement(by); }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return true;
        }

        public static void ScrollToPosition(this IWebDriver driver, int xPos, int yPos) =>
            driver.ExecuteJavaScript($"window.scrollTo({xPos},{yPos})");

        public static string GetElementXpath(this IWebElement element, IWebDriver driver)
        {
            const string javaScript = @"function getElementXPath(elt){
                                      var path = '';
                                      for (; elt && elt.nodeType == 1; elt = elt.parentNode){
                                      idx = getElementIdx(elt);
                                      xname = elt.tagName;
                                      if (idx > 1){
                                      xname += '[' + idx + ']';
                                      }
                                      path = '/' + xname + path;
                                      }
                                      return path;
                                      }
                                      function getElementIdx(elt){
                                      var count = 1;
                                      for (var sib = elt.previousSibling; sib ; sib = sib.previousSibling){
                                      if(sib.nodeType == 1 && sib.tagName == elt.tagName){
                                      count++;
                                      }
                                      }
                                      return count;
                                      }
                                      return getElementXPath(arguments[0]).toLowerCase();";
            return (string)((IJavaScriptExecutor)driver).ExecuteScript(javaScript, element);
        }
    }
}
