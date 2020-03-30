using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace Allegro.AcceptanceTests.PageObjects
{
    public class SearchResultPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator secondHandCbx = new ElementLocator(Locator.XPath, "//span[text()='używane']");
        private readonly ElementLocator priceFromTbx =
            new ElementLocator(Locator.CssSelector, "#price_from");
        private readonly ElementLocator resultItems = new ElementLocator(Locator.CssSelector, "div[data-box-name='Items Container'] article[data-item]");

        public SearchResultPage(DriverContext driverContext)
            : base(driverContext)
        {
        }
        
        public void ClickOnSecondHandCbx()
        {
            this.Driver.GetElement(secondHandCbx).Click();
        }

        public ItemPage ClickItem(int index)
        {
            Logger.Info(CultureInfo.CurrentCulture, $"Clicking item at index {index}");
            //I know it is ugly, but wait for ajax/jquery did not work
            Thread.Sleep(3000);

            this.Driver.GetElements(resultItems)[index].Click();

            return new ItemPage(this.DriverContext);
        }

        public void EnterPriceFrom(double price)
        {
            Logger.Info(CultureInfo.CurrentCulture, $"Setting price from to {price}");
            string priceStr = price.ToString();
            this.Driver.GetElement(priceFromTbx).SendKeys(priceStr);
        }
    }
}
