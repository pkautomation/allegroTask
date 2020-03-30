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
    public class BasketPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator firstBasketItem = new ElementLocator(Locator.CssSelector, "section seller-offers div div div div div div div div a");

        public BasketPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public string GetFirstItemName()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Getting first item name");
            return this.Driver.GetElements(firstBasketItem, 1)[0].Text;
        }

    }
}
