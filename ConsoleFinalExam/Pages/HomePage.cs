using OpenQA.Selenium;

namespace ConsoleFinalExam.Pages
{
    public class HomePage
    {
        #region Locators
        private By locatorFrameLayer => By.ClassName("style-j56p2zs4iframe");

        #endregion

        #region IWebElements
        private static IWebElement ClassicBlendsOption => Driver.Instance.FindElement(By.XPath(""));

        #endregion

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://www.theteastory.co/");
        }
    }
}
