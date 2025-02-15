using FreeShockCE.HELPERS;
using VRC.OSCQuery;

var tcpPort = Extensions.GetAvailableTcpPort();
var udpPort = Extensions.GetAvailableUdpPort();

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

var oscQuery = new OSCQueryServiceBuilder()
    .WithDefaults()
    .WithTcpPort(tcpPort)
    .WithUdpPort(udpPort)
    .WithServiceName("FreeShockCE")
    .Build();

// Manually logging the ports to see them without a logger
Console.WriteLine($"Started OSCQueryService at TCP {tcpPort}, UDP {udpPort}");

// Stops the program from ending until a key is pressed
Console.ReadKey();