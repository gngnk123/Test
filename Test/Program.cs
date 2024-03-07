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

        for (int i = 1; i<= 3;  i++)
        {
            // Find element using XPath: 1)Product name  2)Price  3)Rating
            IWebElement Product = driver.FindElement(By.XPath("/html/body/div["+i+"]/div/h4/a"));
            IWebElement Price = driver.FindElement(By.XPath("/html/body/div["+i+"]/div/div[1]/p/span"));
            // Extract text from the element
            string ProductName = Product.Text;
            string PriceStr = Price.Text;
            string numbersOnly = Regex.Replace(PriceStr, @"[^\d.]", "");
            if (i == 1)
            {
                //For raiting
                IWebElement ProductLink = driver.FindElement(By.XPath("/html/body/div[1]/div/h4/a"));
                ProductLink.Click();
                IWebElement Features = driver.FindElement(By.XPath("//*[@id=\"additional-info-91701\"]/h2/span"));
                Features.Click();
                Thread.Sleep(1000);
                IWebElement Rating = driver.FindElement(By.XPath("//*[@id=\"eso-accordion-target-1-0\"]/div/p[8]"));
                string RatingStr = Rating.Text;
                string numbersOnly2 = Regex.Replace(RatingStr, @"[^\d.]", "");
                Console.WriteLine(numbersOnly2);
                driver.Navigate().Back();
                // Print the extracted text
                Console.WriteLine(i + ") Product: " + ProductName + "\t\t Price: " + numbersOnly + "\t\t Rating: " + numbersOnly2);
            }
            else
                Console.WriteLine(i + ") Product: " + ProductName + "\t\t Price: " + numbersOnly);


        }



        // Close the WebDriver
        driver.Quit();
    }
}