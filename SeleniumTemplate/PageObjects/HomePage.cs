using OpenQA.Selenium;
using SeleniumTestTemplate.Const;
using SeleniumTestTemplate.Enums;
using SeleniumTestTemplate.Helpers;

namespace SeleniumTestTemplate.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, Devices device)
        {
            Driver = driver;
            CurrentDevice = Device.Get(device);
        }

        #region Locators

        public IWebElement CookieBar => Driver.FindElement(By.Id("cc-notification")); // TODO: this is an example
        public IWebElement CookieBarCloseButton => (CookieBar != null) ? CookieBar.FindElement(By.Id("cc-approve-button-thissite")) : null; // TODO: this is an example
        public IWebElement Footer => Driver.FindElement(By.ClassName("app-footer"));

        #endregion //Locators

        public int NumberOfLinksInFooter()
        {
            return Footer.FindElements(By.TagName(ElementType.A)).Count;
        }

        public void CloseCookieBar()
        {
            try
            {
                var button = CookieBarCloseButton;
                if (button == null) return;
                button.Click();
                WaitForAjax();
            }
            catch (NoSuchElementException)
            {
                // Already closed
            }
        }
    }
}
