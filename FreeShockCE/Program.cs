using FreeShockCE.HELPERS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Welcome to FreeShockCE! An opensource project for masochists by masochists!");

await Task.Delay(500);

Console.WriteLine("Startup procedure...");

Console.WriteLine("Loading config..."); // Reading config file stored on disk
var configHelper = new ConfigHelper();

if (!configHelper.LoadConfig("config.json"))
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Press any key to exit...");
    Console.ReadLine();
    
    return;
}

var configData = DataHelper.ConfigData;


// Displaying config data
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("////////////////////////////////////////////////////////////////");
Console.WriteLine($"| OSC Listen Port: {configData.OscPort}");
Console.WriteLine($"| OSC Send Port: {configData.OscSendToPort}");

Console.ForegroundColor = ConsoleColor.Blue;
for (var i = 0; i < configData.PiShocks.Length; i++)
{
    var piShock = configData.PiShocks[i];
    Console.WriteLine($"| PiShock {i + 1} Username: {piShock.Username}");
    Console.WriteLine($"| PiShock {i + 1} API Key: {piShock.ApiKey}");
    Console.WriteLine($"| PiShock {i + 1} Device ID: {piShock.DeviceId}");
}

