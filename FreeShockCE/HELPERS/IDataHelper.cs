using FreeShockCE.Entities;

namespace FreeShockCE.HELPERS;

public interface IDataHelper
{
    static Config ConfigData { get; set; } = new();
}