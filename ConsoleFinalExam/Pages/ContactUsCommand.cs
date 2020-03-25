using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleFinalExam.Pages
{
    public class ContactUsCommand
    {
        public enum ContactDepts
        {
            Sales,
            Accounting
        }

        public enum Country
        {
            UnitedStates,
            Canada
        }

        private By locatorBtnSubmit => By.XPath("//button[@class='mktoButton']");

        #region IWebElements
        private IWebElement txtName => Driver.Instance.FindElement(By.Id("FirstName"));
        private IWebElement txtLastName => Driver.Instance.FindElement(By.Id("LastName"));
        private IWebElement txtEmail => Driver.Instance.FindElement(By.Id("Email"));
        private IWebElement txtJobtitle => Driver.Instance.FindElement(By.Id("Title"));
        private IWebElement txtCompany => Driver.Instance.FindElement(By.Id("Company"));
        private IWebElement selectContactDept => Driver.Instance.FindElement(By.Id("Division_Department__c"));
        private IWebElement selectCountry => Driver.Instance.FindElement(By.Id("Country"));
        private IWebElement txtAreaMessage => Driver.Instance.FindElement(By.Id("comment_capture"));
        private IWebElement btnSubmit => Driver.Instance.FindElement(locatorBtnSubmit);


        #endregion

        public ContactUsCommand WithName(string name)
        {
            try
            {
                txtName.SendKeys(name);
            }
            catch (Exception ex)
            {
                throw new Exception($"First name field can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }

        public ContactUsCommand WithLastName(string lastName)
        {
            try
            {
                txtLastName.SendKeys(lastName);
            }
            catch (Exception ex)
            {
                throw new Exception($"First name field can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }

        public ContactUsCommand WithEmailAddress(string email)
        {
            try
            {
                txtEmail.SendKeys(email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Email field can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }

        public ContactUsCommand WithJobTitle(string jobTitle)
        {
            try
            {
                txtJobtitle.SendKeys(jobTitle);
            }
            catch (Exception ex)
            {
                throw new Exception($"Job Title field can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }

        public ContactUsCommand WithCompany(string company)
        {
            try
            {
                txtCompany.SendKeys(company);
            }
            catch (Exception ex)
            {
                throw new Exception($"Company field can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }

        public ContactUsCommand WithContactDepartment(ContactDepts deptOption)
        {
            SelectElement selectDeptOption;

            try
            {
                selectDeptOption = new SelectElement(selectContactDept);
            }
            catch (Exception ex)
            {
                throw new Exception($"Contact Department Dropdown can't be found by Selenium \n Details: {ex.Message}");
            }
            
            switch (deptOption)
            {
                case ContactDepts.Sales:
                    selectDeptOption.SelectByText("Sales");

                    break;

                case ContactDepts.Accounting:
                    selectDeptOption.SelectByText("Accounting");

                    break;

                default:
                    break;
            }

            return this;
        }

        public ContactUsCommand WithCountry(Country countryOption)
        {
            SelectElement selectCountryOption;

            try
            {
                selectCountryOption = new SelectElement(selectCountry);
            }
            catch (Exception ex)
            {
                throw new Exception($"Country Dropdown field can't be found by Selenium \n Details: {ex.Message}");
            }

            switch (countryOption)
            {
                case Country.UnitedStates:
                    selectCountryOption.SelectByText("United States");

                    break;

                case Country.Canada:
                    selectCountryOption.SelectByText("Canada");

                    break;

                default:
                    break;
            }

            return this;
        }

        public ContactUsCommand WithMessage(string message)
        {
            try
            {
                txtAreaMessage.SendKeys(message);
                txtAreaMessage.SendKeys(Keys.Tab);
            }
            catch (Exception ex)
            {
                throw new Exception($"Message text area can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }

        public ContactUsCommand PressSubmitButton()
        {
            Helper.WaitUntilElementClickable(locatorBtnSubmit);
            Helper.ScrollToView(locatorBtnSubmit);

            //Actions actions = new Actions(Driver.Instance);
            //actions.MoveToElement(btnSubmit);
            //actions.Perform();

            try
            {
                btnSubmit.Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"Submit button can't be found by Selenium \n Details: {ex.Message}");
            }

            return this;
        }
    }
}