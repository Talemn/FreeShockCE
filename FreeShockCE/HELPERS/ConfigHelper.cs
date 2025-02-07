using FreeShockCE.Entities;
using Newtonsoft.Json;

namespace FreeShockCE.HELPERS;

public class ConfigHelper : IConfigHelper
{
    
public bool LoadConfig(string filePath)
{
    if (!File.Exists(filePath))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[ERROR]Config file not found! Generating new config file...");
        
        var defaultConfig = new Config
        {
            PiShocks =
            [
                new PiShockDevice
                {
                    DeviceId = "your_device_id"
                },
                new PiShockDevice
                {
                    DeviceId = "your_device_id"
                },
                new PiShockDevice
                {
                    DeviceId = "your_device_id"
                }
            ],
            OscPort = 9001,
            OscSendToPort = 9000,
            ShockDelay = 3,
            ShockerParam = new ShockerParam
            {
                PowerMin = 0,
                PowerMax = 15,
                DurationMin = 0.5,
                DurationMax = 1,
                Cooldown = 15,
                IsActive = false, // Default to false to prevent accidental shocks
                IsPower = false,
                IsVibration = false,
                IsCooldown = false
            }
        };
        
        var jsonRaw = JsonConvert.SerializeObject(defaultConfig, Formatting.Indented);

        // Save it to the specified file path
        File.WriteAllText(filePath, jsonRaw);

        Console.WriteLine($"Default config file created at: {filePath}");
        Console.WriteLine("Please edit the config file and restart the application.");
        
        return false;
    }
    
    
    var json = File.ReadAllText(filePath);
    var config = JsonConvert.DeserializeObject<Config>(json);

    if (config == null)
    {
        Console.WriteLine("Config file is empty or invalid");
        return false;
    }
    
    DataHelper.ConfigData = config;
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Configuration ini loaded!");

    return true;
}



}