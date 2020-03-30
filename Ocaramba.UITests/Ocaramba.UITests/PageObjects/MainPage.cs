using System;
using System.Globalization;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Allegro.AcceptanceTests.PageObjects
{
    public class MainPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator searchBox =
            new ElementLocator(Locator.CssSelector, "[data-role='search-input']");
        private readonly ElementLocator searchBtn =
            new ElementLocator(Locator.CssSelector, "[data-role='search-button']");
        private readonly ElementLocator dataConsentAcceptBtn =
            new ElementLocator(Locator.CssSelector, "[data-role='accept-consent']");

        public MainPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public void OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            Logger.Info(CultureInfo.CurrentCulture, $"Opening page {url}");
            this.Driver.NavigateTo(new Uri(url));
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public void GoToPage(string page)
        {
        }

        public SearchResultPage SearchForProduct(string txt)
        {
            Logger.Info(CultureInfo.CurrentCulture, $"Searching for {txt}");
            this.Driver.GetElement(searchBox).SendKeys(txt);
            this.Driver.GetElement(searchBtn).Click();

            return new SearchResultPage(DriverContext);
        }

        public void AcceptDataConsent()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Accepting data consent(cookies)");
            this.Driver.GetElement(dataConsentAcceptBtn).Click();
        }
    }
}
