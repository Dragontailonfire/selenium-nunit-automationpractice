using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace ProjectComponents.components
{
    public class WebDriverManager
    {
        private static IWebDriver _webDriver;

        public static IWebDriver Driver
        {
            get
            {
                return LaunchDriver();
            }
        }

        public static IWebDriver LaunchDriver()
        {
            if(_webDriver != null)
            {
                return _webDriver;
            }
            var config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            string browser = config["test_browser"];
            string browserPath = Directory.GetCurrentDirectory() + config["test_browser_path"];

            switch (browser)
            {
                case "Chrome": _webDriver = new ChromeDriver(browserPath); 
                    break;
                case "Firefox":
                    _webDriver = new FirefoxDriver(browserPath);
                    break;
                case "IE":
                    _webDriver = new InternetExplorerDriver(browserPath);
                    break;
                default: throw new Exception("No proper Browser name given in config");
            }
            return _webDriver;
        }

        public static void DisposeDriver()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
            }
            _webDriver = null;
        }
    }
}
