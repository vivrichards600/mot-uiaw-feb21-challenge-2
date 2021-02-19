using Challenge_2.Pages;
using NUnit.Framework;

namespace Challenge_2
{
    //    Welcome to UI Automation Challenge 2
    //
    //    For this challenge it's all about creating clean, readable and maintainable code. Below
    //    are five tests that work (just about) but require cleaning up. Update this code base
    //    so that it's easier to maintain, more readable, and has sensible ways of asserting
    //    data. You might want to research different approaches to improving UI automation such as
    //    Page Object Models and implicit vs. explicit waits, as well as NUnit features that can make things
    //    easier to maintain

    public class Challenge2Tests : BasePage
    {
        //  Test one: Check to see if you can log in with valid credentials
        [Test]
        public void VerifyCanLoginWithValidCredentials()
        {
            adminPage.GoToPage();
            adminPage.Login();
            
            Assert.That(roomsPage.IsDisplayed());
        }

        //  Test two: Check to see if rooms are saved and displayed in the UI
        [Test]
        public void VerifyRoomsAreSavedAndDisplayedInUI()
        {
            adminPage.GoToPage();
            adminPage.Login();
            roomsPage.CreateBooking();
         
            Assert.That(roomsPage.ContainsNewBooking());
        }

        //  Test three: Check to see the confirm message appears when branding is updated
        [Test]
        public void VerifyConfirmMessageAppearsWhenBrandingIsUpdated()
        {
            adminPage.Login();
            brandingPage.UpdateBranding();

            Assert.That(brandingPage.UpdatedConfirmationDisplayed());
        }

        //  Test four: Check to see if the contact form shows a success message
        [Test]
        public void VerifyContactFormShowsSuccessMessage()
        {
            contactPage.SendMessage();

            Assert.That(contactPage.MessageIsSent());
        }

        //  Test five: Check to see if unread messages are bolded
        [Test]
        public void VerifyUnreadMessagesAreBolded()
        { 
            adminPage.Login();
            messagesPage.GoToPage();
         
            Assert.That(messagesPage.AllUnreadMessagesAreBold);
        }
    }
}