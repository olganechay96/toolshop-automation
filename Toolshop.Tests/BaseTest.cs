using Microsoft.Playwright;
using Toolshop.Core;

namespace Toolshop.Tests;

public abstract class BaseTest
{
    private const string BaseUrl = "https://practicesoftwaretesting.com";
    private BrowserSession _session = null!;
    protected IPage Page { get; private set; } = null!;
    
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        _session = new BrowserSession(BaseUrl);
        await _session.LaunchBrowserAsync();
    }

    [SetUp]
    public async Task SetUp()
    {
        Page = await _session.OpenNewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await _session.CloseContextAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _session.CloseAllAsync();
    }
}