using OpenQA.Selenium;
using SeleniumTestTemplate.Models;
using System.Threading;

namespace SeleniumTestTemplate.PageObjects
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; set; }
        public DeviceModel CurrentDevice { get; set; }

        public void WaitForAjax()
        {
            while (true) // Handle timeout somewhere
            {
                var ajaxIsComplete = (bool)((Driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
                if (ajaxIsComplete)
                    break;
                Thread.Sleep(100);
            }
        }

        public void ScrollToTop()
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,0);");
        }

        public void ScrollToBottom()
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }

        public void FillFormValue(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
            element.SendKeys(Keys.Tab);
            element.Click();
        }
    }
}
