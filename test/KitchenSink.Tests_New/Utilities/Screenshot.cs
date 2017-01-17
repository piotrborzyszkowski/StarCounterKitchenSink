using System;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using NUnit.Framework;

namespace KitchenSink.Test
{
    class Screenshot
    {
        public static void MakeScreenshot(IWebDriver driver)
        {
            var driverScreenshot = driver as ITakesScreenshot;
            if (null != driverScreenshot)
            {
                var screenShot = driverScreenshot.GetScreenshot();
                if (null != screenShot)
                {
                    var now = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var path = string.Format(@"\webdriver_screenshot_{0}.png", now);

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
