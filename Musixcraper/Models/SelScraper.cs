using System;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Musixcraper.Models
{
    public class SelScraper
    {
        string userInput;

        public SelScraper(string _userInput)
        {
            userInput = _userInput;
        }

        public string ExtractLyrics()
        {
            IWebDriver driver = new ChromeDriver("/Users/kik/Downloads");

            //driver.Navigate().GoToUrl("https://www.musixmatch.com");

            //IWebElement searchInput = driver.FindElement(By.ClassName("mui-input--search-bar"));

            //searchInput.SendKeys("Woman");

            //searchInput.Submit();

            driver.Navigate().GoToUrl("https://www.musixmatch.com/search/"+this.userInput);

            IWebElement songElt = driver.FindElement(By.ClassName("title"));

            songElt.Click();



            List<IWebElement> lyricsElts = driver.FindElements(By.ClassName("lyrics__content__ok")).ToList();

            string lyrics = "";

            foreach(var lyricsElt in lyricsElts)
            {
                lyrics += lyricsElt.Text;
            }

            return lyrics;
        }
    }
}
