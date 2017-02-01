using System;

namespace KitchenSink.Tests.Utilities
{
    public class Config
    {
        public static readonly TimeSpan Timeout = TimeSpan.FromSeconds(60);
        public static readonly Uri KitchenSinkUrl = new Uri("http://localhost:8080/KitchenSink");
        public static readonly Uri RemoteWebDriverUri = new Uri("http://localhost:4444/wd/hub");

        public enum Browser
        {
            Chrome,
            Edge,
            Firefox
        }
    }
}
