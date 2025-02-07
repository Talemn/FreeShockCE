using FreeShockCE.HELPERS;
using System;
using System.Threading.Tasks;
using FastOSC;
using FreeShockCE.Entities;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Welcome to FreeShockCE! An open-source project for masochists by masochists!");

await Task.Delay(500);

Console.WriteLine("Startup procedure...");
Console.WriteLine("Loading config...");

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
    Console.WriteLine($"| PiShock {i + 1} Device ID: {piShock.DeviceId}");
}

Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("////////////////////////////////////////////////////////////////");

Console.ResetColor();

OscHelper.StartOscListener();

while (true)
{
    OscHelper.Receiver.OnMessageReceived += message =>
    {
        Console.WriteLine($"Received message in bundle: {message.Address} with values: {string.Join(", ", message.Arguments)}");
    };
    OscHelper.Receiver.OnBundleReceived += _ =>
    {
    };
    Task.Delay(50).Wait();
}