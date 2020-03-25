using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFinalExam.Pages
{
    public class ThankYouContactUsPage
    {
        private static By locatorLblThankYou => By.ClassName("content-page__inner");
        private static IWebElement lblThankYou => Driver.Instance.FindElement(locatorLblThankYou);
        public static bool IsContactFormSend()
        {
            var result = false;
            Helper.WaitUntilElementVisible(locatorLblThankYou);

            if (lblThankYou.Text.Contains("THANK YOU"))
                result = true;

            return result;
        }
    }
}
