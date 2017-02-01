using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace KitchenSink.Tests.Utilities
{
    class EventListener : EventFiringWebDriver
    {
        public EventListener(IWebDriver driver) : base(driver)
        {
            ExceptionThrown += (sender, e) =>
            {
                if (e != null && sender != null)
                {
                    Screenshot.MakeScreenshot(e.Driver);
                }
            };
        }
    }
}