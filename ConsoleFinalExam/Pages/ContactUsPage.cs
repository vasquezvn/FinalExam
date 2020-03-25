namespace ConsoleFinalExam.Pages
{
    public class ContactUsPage
    {
        public static ContactUsCommand WithName(string name)
        {
            return new ContactUsCommand().WithName(name);
        }

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://www.niceincontact.com/contact-us");
        }
    }
}
