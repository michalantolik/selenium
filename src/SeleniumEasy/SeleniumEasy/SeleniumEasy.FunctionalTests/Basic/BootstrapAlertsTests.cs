using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class BootstrapAlertsTests
    {
        [Fact]
        public void AutocloseSuccessAlert()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var bootstrapAlertsPage = new BootstrapAlertsPage(driver);
                bootstrapAlertsPage.NavigateTo();

                // Click button to open autoclose success alert
                bootstrapAlertsPage.ClickAutocloseSuccessButton();
                Assert.True(bootstrapAlertsPage.AutocloseSuccessAlertIsDisplayed());

                // Wait and verify that alert got auto-closed
                var timeout = TimeSpan.FromSeconds(10);
                Assert.True(bootstrapAlertsPage.AutocloseSuccessAlertIsNotDisplayed(timeout));
            }
        }

        [Fact]
        public void NormalSuccessAlert()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var bootstrapAlertsPage = new BootstrapAlertsPage(driver);
                bootstrapAlertsPage.NavigateTo();

                // Click button to open normal success alert
                bootstrapAlertsPage.ClickNormalSuccessButton();
                Assert.True(bootstrapAlertsPage.NormalSuccessAlertIsDisplayed());

                // Close alert with "X" button
                bootstrapAlertsPage.CloseNormalSuccessAlert();

                // Verify that alert got closed
                Assert.False(bootstrapAlertsPage.NormalSuccessAlertIsDisplayed());
            }
        }
    }
}
