using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Toolshop.Tests;

public class HomePageTests : BaseTest
{
    [Test]
    public async Task HomePage_Opens()
    {
        await Page.GotoAsync("/");

        var homeLink = Page.GetByRole(AriaRole.Link, new() { Name = "Home" });
        await Expect(homeLink).ToBeVisibleAsync();
    }

    [Test]
    public async Task HomePage_SignIn_Link_Is_Available()
    {
        await Page.GotoAsync("/");

        var signInLink = Page.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
        await Expect(signInLink).ToBeVisibleAsync();
    }
}