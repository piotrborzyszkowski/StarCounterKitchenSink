using System;
using System.Drawing.Imaging;
using NUnit.Framework;
using OpenQA.Selenium;

namespace KitchenSink.Tests.Utilities
{
    class Screenshot
    {
        public static void MakeScreenshot(IWebDriver driver)
        {
            var driverScreenshot = driver as ITakesScreenshot;
            if (null != driverScreenshot)
            {
                var screenShot = driverScreenshot.GetScreenshot();
                if (screenShot != null)
                {
                    var now = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var path = $@"\webdriver_screenshot_{now}.png";

                    screenShot.SaveAsFile(TestContext.CurrentContext.TestDirectory + path, ImageFormat.Png);
                }
                else
                {
                    throw new Exception("GetScreenshot() retured null, can't save file!");
                }
            }
            else
            {
                throw new Exception("Can't cast driver as ITakesScreenshot!");
            }
        }
    }
}
