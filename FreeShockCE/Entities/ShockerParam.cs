namespace FreeShockCE.Entities;

public class ShockerParam
{
    public int PowerMin { get; set; } = 0;
    public int PowerMax { get; set; } = 15;
    public double DurationMin { get; set; } = 0.5;
    public double DurationMax { get; set; } = 1;
    public double Cooldown { get; set; } = 15;
    public bool IsActive { get; set; } = false;
    public bool IsPower { get; set; } = false;
    public bool IsVibration { get; set; } = false;
    public bool IsCooldown { get; set; } = false;
}