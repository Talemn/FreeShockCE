namespace FreeShockCE.Entities;

public class Config
{
    public PiShockDevice[] PiShocks { get; set; } = [];
    public int OscPort { get; set; }
    public int OscSendToPort { get; set; }
    public int ShockDelay { get; set; }
    public ShockerParam ShockerParam { get; set; } = new ShockerParam();
}