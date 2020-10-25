using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class JavaScriptAlertsTests
    {
        [Fact]
        public void SimpleAlert_OpenAndClose()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var alertPage = new JavaScriptAlertsPage(driver);
                alertPage.NavigateTo();

                // Open simple alert
                alertPage.ClickSimpleAlertButton();

                // Verify that simple alert got opened and its text
                Assert.True(alertPage.AlertIsPresent());
                var alert = alertPage.SwitchToAlert();
                Assert.Equal("I am an alert box!", alert.Text);

                // Close simple alert
                alert.Accept();

                // Verify that simple alert got closed
                alertPage.EnsurePageLoaded();
                Assert.False(alertPage.AlertIsPresent());
            }
        }

        [Fact]
        public void ConfirmationAlert_OpenAndClose()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var alertPage = new JavaScriptAlertsPage(driver);
                alertPage.NavigateTo();

                // Verify that confirmation alert status text is empty by default
                Assert.Equal("", alertPage.GetConfirmationAlertStatus());

                // Open confirmation alert and close with "OK"
                alertPage.ClickConfirmationAlertButton();

                Assert.True(alertPage.AlertIsPresent());
                var alert = alertPage.SwitchToAlert();
                Assert.Equal("Press a button!", alert.Text);

                alert.Accept();

                alertPage.EnsurePageLoaded();
                Assert.False(alertPage.AlertIsPresent());
                Assert.Equal("You pressed OK!", alertPage.GetConfirmationAlertStatus());

                // Open confirmation alert and close with "Cancel"
                alertPage.ClickConfirmationAlertButton();

                Assert.True(alertPage.AlertIsPresent());
                alert = alertPage.SwitchToAlert();
                Assert.Equal("Press a button!", alert.Text);

                alert.Dismiss();

                alertPage.EnsurePageLoaded();
                Assert.False(alertPage.AlertIsPresent());
                Assert.Equal("You pressed Cancel!", alertPage.GetConfirmationAlertStatus());
            }
        }

        [Fact]
        public void PromptAlert_OpenAndClose()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var alertPage = new JavaScriptAlertsPage(driver);
                alertPage.NavigateTo();

                // Verify that prompt alert status text is empty by default
                Assert.Equal("", alertPage.GetPromptAlertStatus());

                // Open prompt alert, enter name and close with "Cancel"
                alertPage.ClickPromptAlertButton();

                Assert.True(alertPage.AlertIsPresent());
                var alert = alertPage.SwitchToAlert();
                Assert.Equal("Please enter your name", alert.Text);
                alert.SendKeys("John");

                alert.Dismiss();

                alertPage.EnsurePageLoaded();
                Assert.False(alertPage.AlertIsPresent());
                Assert.Equal("", alertPage.GetPromptAlertStatus());

                // Open prompt alert, enter name and close with "OK"
                alertPage.ClickPromptAlertButton();

                Assert.True(alertPage.AlertIsPresent());
                alert = alertPage.SwitchToAlert();
                Assert.Equal("Please enter your name", alert.Text);
                alert.SendKeys("John");

                alert.Accept();

                alertPage.EnsurePageLoaded();
                Assert.False(alertPage.AlertIsPresent());
                Assert.Equal("You have entered 'John' !", alertPage.GetPromptAlertStatus());
            }
        }
    }
}
