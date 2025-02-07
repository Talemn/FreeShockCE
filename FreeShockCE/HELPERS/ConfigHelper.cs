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

    return true;
}

}