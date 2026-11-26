using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Toolshop.Tests;

public class HomePageTests
{
    private const string BaseUrl = "https://practicesoftwaretesting.com";

    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync();
    }

    [SetUp]
    public async Task SetUp()
    {
        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }

    [Test]
    public async Task HomePage_Opens()
    {
        await _page.GotoAsync(BaseUrl);

        var homeLink = _page.GetByRole(AriaRole.Link, new() { Name = "Home" });
        await Expect(homeLink).ToBeVisibleAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await _context.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}