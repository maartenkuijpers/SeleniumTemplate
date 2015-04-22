﻿using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestTemplate.Extensions;
using SeleniumTestTemplate.Helpers;

namespace SeleniumTestTemplate.Business 
{
    public class SeleniumBase
    {
        protected static IWebDriver Driver;
        public TestContext TestContext { get; set; }

        

        protected string BaseUrl
        {
            get
            {
                var publishProfile = ConfigurationManager.AppSettings["PublishProfile"];
                if (string.IsNullOrWhiteSpace(publishProfile))
                {
                    publishProfile = "Default";
                }

                var baseUrlKey = string.Format("BaseUrl:{0}", publishProfile);

                var baseUrl = ConfigurationManager.AppSettings[baseUrlKey];

                return baseUrl;
            }
        }

        protected void SetupDriver()
        {
            Console.WriteLine("Setting up web driver using base url '{0}'", BaseUrl);
            Driver = SeleniumDriverHelper.GetDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            Driver.Manage().Window.Maximize();
        }

        protected void SetupMobileDriver(string userAgent)
        {
            var profile = new FirefoxProfile();
            profile.SetPreference("general.useragent.override", userAgent);
            Driver = new FirefoxDriver(profile);
        }

        protected void Goto(string page)
        {
            if (!page.StartsWith("/"))
            {
                page = "/" + page;
            }

            page = string.Format("{0}{1}", BaseUrl, page);

            Console.WriteLine("Going to page: {0}", page);
            Driver.Navigate().GoToUrl(page);
        }

        protected static void Set(string type, string id, string value)
        {
            switch (type)
            {
                case ElementType.Select:
                    Driver.GetElementByAttribute(type, AttributeType.Id, id).SelectByValue(value);
                    break;
                case ElementType.Input:
                    Driver.GetElementByAttribute(type, AttributeType.Id, id).CustomSendKeys(value);
                    break;
                case ElementType.CheckBox:
                    if (Driver.GetElementByAttribute(ElementType.Input, id, value).GetAttribute("Checked") == "Checked")
                    {
                        Driver.GetElementByAttribute(ElementType.Input, id, value).Click();
                    }
                    Driver.GetElementByAttribute(ElementType.Input, id, value).Click();
                    break;

            }
        }

        protected static bool Check(string type, string id, string valueShouldBe)
        {
            switch (type)
            {
                case ElementType.Select:
                    return Driver.GetElementByAttribute(type, AttributeType.Id, id).GetSelectedValue() == valueShouldBe;
                case ElementType.Input:
                    return Driver.GetElementByAttribute(type, AttributeType.Id, id).GetValue() == valueShouldBe;
                case ElementType.CheckBox:
                    return Driver.GetElementByAttribute(ElementType.Input, AttributeType.Value, valueShouldBe).GetAttribute("Checked") == "true";
            }

            return false;
        }

        protected void SubmitData()
        {
            Driver.GetElementByAttribute(ElementType.Button, AttributeType.Type, "submit").Click();
        }
    }
}
