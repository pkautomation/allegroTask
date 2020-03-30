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
    public class ItemPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator addToCartBtn = new ElementLocator(Locator.CssSelector, "button[id='add-to-cart-button']");
        private readonly ElementLocator goToCartBtn = new ElementLocator(Locator.XPath, "//*[text()='przejdź do koszyka']");
        private readonly ElementLocator itemNameLbl= new ElementLocator(Locator.CssSelector, "[data-role='app-container'] h1");

        public ItemPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void ClickAddToCart()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking add to cart");
            this.Driver.GetElement(addToCartBtn).Click();
        }

        public BasketPage ClickGoToCart()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Clicking go to cart");
            this.Driver.GetElement(goToCartBtn).Click();

            return new BasketPage(this.DriverContext);
        }
        public string GetItemTitle()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Getting item title");
            return this.Driver.GetElement(itemNameLbl).Text;
        }
    }
}
