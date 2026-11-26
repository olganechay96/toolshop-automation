# toolshop-automation

Test automation framework
Contains API, UI And Integration automation tests for Toolshop application.

## How to run

1. Install .NET SDK, .NET 11 and PowerShell 7
2. Build the project:
   ```dotnet build```
3. Install Playwright browsers:
   ```pwsh Toolshop.Tests/bin/Debug/net11.0/playwright.ps1 install chromium```
4. Run tests:
   ```dotnet test```