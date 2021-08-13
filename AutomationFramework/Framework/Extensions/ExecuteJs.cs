using System;
using OpenQA.Selenium;

namespace AutomationFramework.Framework.Extensions
{
    public static class ExecuteJs
    {
        public static void ExecuteJavaScript(this IWebDriver driver, string script, params object[] args)
        {
            ExecuteJavaScriptInternal(driver, script, args);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window
        /// </summary>
        /// <typeparam name="T">Expected return type of the JavaScript execution.</typeparam>
        /// <param name="driver">The driver instance to extend.</param>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        /// <exception cref="WebDriverException">Thrown if this <see cref="IWebDriver"/> instance
        /// does not implement <see cref="IJavaScriptExecutor"/>, or if the actual return type
        /// of the JavaScript execution does not match the expected type.</exception>
        public static T ExecuteJavaScript<T>(this IWebDriver driver, string script, params object[] args)
        {
            var value = ExecuteJavaScriptInternal(driver, script, args);
            var result = default(T);
            Type type = typeof(T);
            if (value == null)
            {
                if (type.IsValueType && (Nullable.GetUnderlyingType(type) == null))
                {
                    throw new WebDriverException("Script returned null, but desired type is a value type");
                }
            }
            else if (!type.IsInstanceOfType(value))
            {
                throw new WebDriverException("Script returned a value, but the result could not be cast to the desired type");
            }
            else
            {
                result = (T)value;
            }

            return result;
        }

        private static object ExecuteJavaScriptInternal(IWebDriver driver, string script, object[] args)
        {
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            if (executor == null)
            {
                throw new WebDriverException("Driver does not implement IJavaScriptExecutor");
            }

            return executor.ExecuteScript(script, args);
        }
    }
}
