namespace FreeShockCE.Entities;

public class Config
{
    public PiShockDevice[] PiShocks { get; set; } = [];
    
    public string Username { get; set; } = "";
    
    public string ApiKey { get; set; } = "";
    public int OscPort { get; set; }
    public int OscSendToPort { get; set; }
    public int ShockDelay { get; set; }
    public ShockerParam ShockerParam { get; set; } = new ShockerParam();
}