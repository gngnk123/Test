using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        // Set up Chrome WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the webpage you want to scrape
        driver.Navigate().GoToUrl("");

        // Find element using XPath
        IWebElement element = driver.FindElement(By.XPath("//div[@class='example']"));

        // Extract text from the element
        string text = element.Text;

        // Print the extracted text
        Console.WriteLine("Extracted Text: " + text);

        // Close the WebDriver
        driver.Quit();
    }
}