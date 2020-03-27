using ConsoleFinalExam;
using ConsoleFinalExam.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiFinalExam;

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
            var result = ConsoleFinalExam.Program.IsNumberHasMoreThanThreePrimesNumbers(77);

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

        [TestMethod]
        public void VerifyFirstStudent()
        {
            var expectedStudent = new Student() { id = 1, firstName = "Vernon", 
                lastName = "Harper", 
                email = "egestas.rhoncus.Proin@massaQuisqueporttitor.org", 
                programme = "Financial Analysis",
                courses = new string[] { "Accounting", "Statistics" }
            };



            //var isFirstJsonStudent = ApiFinalExam.Program.IsFirstStudent(expectedStudent);

            //Assert.IsTrue(isFirstJsonStudent, "It is not First Student");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
