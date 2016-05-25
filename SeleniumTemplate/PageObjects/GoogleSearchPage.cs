using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumTestTemplate.Const;
using SeleniumTestTemplate.Enums;
using SeleniumTestTemplate.Helpers;

namespace SeleniumTestTemplate.PageObjects
{
    public class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver, Devices device)
        {
            Driver = driver;
            CurrentDevice = Device.Get(device);
        }

        #region Locators

        private IWebElement SearchBox => Driver.GetElementByAttribute(ElementType.Input, AttributeType.Id, "lst-ib");
        private IWebElement SearchButton => Driver.GetElementByAttribute(ElementType.Button, AttributeType.Class, "lsb");
        private IReadOnlyCollection<IWebElement> Results => Driver.GetElementsByAttribute(ElementType.Li, AttributeType.Class, "g");

        #endregion //Locators

        public void SearchFor(string query)
        {
            SearchBox.SendKeys(query);
            SearchButton.Click();
        }

        public int CountSearchResults()
        {
            return (CurrentDevice.Type != DeviceType.Mobile) ? Results.Count : Driver.GetElementsByAttribute(ElementType.Div, AttributeType.Class, "mnr-c").Count;
        }
    }
}
