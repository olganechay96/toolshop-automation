using Microsoft.Playwright;
namespace Toolshop.Core;

public class BrowserSession
{
    private readonly string _baseUrl ;
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IBrowserContext _context = null!;


    public BrowserSession(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task LaunchBrowserAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync();
    }

    public async Task<IPage> OpenNewPageAsync()
    {
        _context = await _browser.NewContextAsync(new(){BaseURL = _baseUrl});
        return await _context.NewPageAsync();
    }

    public async Task CloseContextAsync()
    {
        if (_context is not null) await _context.CloseAsync();
    }

    public async Task CloseAllAsync()
    {
        if (_browser is not null) await _browser.CloseAsync();
        _playwright?.Dispose();
    }
}