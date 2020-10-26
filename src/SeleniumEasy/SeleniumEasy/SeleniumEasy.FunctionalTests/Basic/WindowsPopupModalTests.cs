using OpenQA.Selenium.Chrome;
using SeleniumEasy.FunctionalTests.Extensions;
using Xunit;

namespace SeleniumEasy.FunctionalTests.Basic
{
    public class WindowsPopupModalTests
    {
        [Fact]
        public void SingleWindowPopup_OpenAndClose()
        {
            using (var driver = new ChromeDriver())
            {
                // Go to page
                var windowPopupPage = new WindowPopupModalPage(driver);
                windowPopupPage.NavigateTo();

                // Click follow on Twitter button and verify that window got open
                // ... then close it and verify if got closed
                var twitterWindowTitle = "Selenium Easy (@seleniumeasy) / Twitter";
                windowPopupPage.ClickFollowOnTwitterButton();
                Assert.True(driver.WindowIsOpen(twitterWindowTitle));
                driver.CloseWindow(twitterWindowTitle);
                Assert.False(driver.WindowIsOpen(twitterWindowTitle));

                // Click follow on Twitter button and verify that window got open
                // ... then close it and verify if got closed
                var facebookWindowTitle = "Selenium Easy - Home | Facebook";
                windowPopupPage.ClickLikeUsOnFacebookButton();
                Assert.True(driver.WindowIsOpen(facebookWindowTitle));
                driver.CloseWindow(facebookWindowTitle);
                Assert.False(driver.WindowIsOpen(facebookWindowTitle));
            }
        }
    }
}
