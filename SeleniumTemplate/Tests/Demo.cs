using FluentAssertions;
using NUnit.Framework;
using SeleniumTestTemplate.Business;
using SeleniumTestTemplate.Const;
using SeleniumTestTemplate.Enums;
using SeleniumTestTemplate.Helpers;
using SeleniumTestTemplate.PageObjects;

namespace SeleniumTestTemplate.Tests
{
    [TestFixture(Devices.Ipad)]
    [TestFixture(Devices.Nexus5)]
    [TestFixture(Devices.Desktop)]
    public class Demo : SeleniumBase
    {
        private Devices _device;
        public Demo()
        {
            _device = Devices.Desktop;
        }

        public Demo(Devices device)
        {
            _device = device;
        }

        private const string Url = "/";

        [SetUp]
        public void Initialize()
        {
            SetupDriver(_device);
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }

        [Test]
        public void SearchOnGoogle()
        {
            Goto(Url); // see app.config for domain
            var page = new GoogleSearchPage(Driver, _device);
            page.SearchFor("Selenium tests");

            const int expectedResult = 5;
            var actualResult = page.CountSearchResults();

            actualResult.Should().BeGreaterOrEqualTo(expectedResult);
        }
    }
}
