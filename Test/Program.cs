using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        // Chrome WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the webpage
        driver.Navigate().GoToUrl("https://gngnk123.github.io/Test/Test/Webpage.html");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        for (int i = 1; i<= 3;  i++)
        {
            // Find element using XPath: 1)Product name  2)Price  3)Rating
            IWebElement Product = driver.FindElement(By.XPath("/html/body/div["+i+"]/div/h4/a"));
            IWebElement Price = driver.FindElement(By.XPath("/html/body/div["+i+"]/div/div[1]/p/span"));
            // Extract text from the element
            string ProductName = Product.Text;
            string PriceStr = Price.Text;
            string numbersOnly = Regex.Replace(PriceStr, @"[^\d.]", ""); //To get only numeric value with (.) of price
            if (i == 1)
            {
                //For raiting
                IWebElement ProductLink = driver.FindElement(By.XPath("/html/body/div[1]/div/h4/a"));
                ProductLink.Click();    //Go to Product page
                IWebElement Features = driver.FindElement(By.XPath("//*[@id=\"additional-info-91701\"]/h2/span"));
                Features.Click();       //Looking for Rating in Features section
                Thread.Sleep(1000);
                IWebElement Rating = driver.FindElement(By.XPath("//*[@id=\"eso-accordion-target-1-0\"]/div/p[8]"));
                string RatingStr = Rating.Text;
                string numbersOnly2 = Regex.Replace(RatingStr, @"[^\d.]", "");
                driver.Navigate().Back();  //Go back to starting page
                // Print the extracted text
                Console.WriteLine(i + ") Product: " + ProductName + "\t\t Price: " + numbersOnly + "\t\t Rating: " + numbersOnly2);
            }
            //There are no ratings for last two products so I had to print that "This item hasn't been reviewed yet".
            else
            {
                IWebElement ProductLink = driver.FindElement(By.XPath("/html/body/div["+i+"]/div/h4/a"));
                ProductLink.Click(); //Go to Product page
                IWebElement Rating2 = driver.FindElement(By.XPath("//*[@id=\"page-content\"]/div/div[2]/section/div[2]/div[2]/p"));
                string Rating2Str = Rating2.Text;
                driver.Navigate().Back();
                Thread.Sleep(1000);
                Console.WriteLine(i + ") Product: " + ProductName + "\t\t Price: " + numbersOnly + "\t\t Rating: " + Rating2Str);
                Thread.Sleep(1000);
            }

        }

        Thread.Sleep(5000);
        // Close the WebDriver
        driver.Quit();
    }
}