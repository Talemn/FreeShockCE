using FreeShockCE.Entities;

namespace FreeShockCE.HELPERS;

public abstract class DataHelper : IDataHelper
{
    public static Config ConfigData { get; set; } = new();
}