using System;

namespace KitchenSink.Tests_New.Utilities
{
    public class Config
    {
        public static readonly double Timeout = 60;
        public static readonly double ImplicitlyTimeout = 60;
        public static readonly Uri Url = new Uri("http://localhost:8080/KitchenSink/MainPage");
        public static readonly Uri RemoteWebDriverUri = new Uri("http://127.0.0.1:4444/wd/hub");

        public enum Browser
        {
            Chrome,
            Edge,
            Firefox
        }
    }
}
