using ConsoleFinalExam;
using ConsoleFinalExam.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalExam
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }


        [TestMethod]
        public void VerifyPrimeNumbers()
        {
            var result = Program.IsNumberHasMoreThanThreePrimesNumbers(77);

            Assert.IsTrue(result, "Number doesn't have more than three numbers");
        }

        [TestMethod]
        public void VerifySalesInquiryHasBeenSubmitted()
        {
            ContactUsPage.GoTo();

            ContactUsPage.WithName("Lucas")
                .WithLastName("test")
                .WithEmailAddress("lucas@test.com")
                .WithJobTitle("Developer")
                .WithCompany("NICE")
                .WithContactDepartment(ContactUsCommand.ContactDepts.Accounting)
                .WithCountry(ContactUsCommand.Country.Canada)
                .WithMessage("Hola test message")
                .PressSubmitButton();

            var isContacted = ThankYouContactUsPage.IsContactFormSend();

            Assert.IsTrue(isContacted, "Contact Page has been sent correctly");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
