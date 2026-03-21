using System.Reflection;
using BepInEx.Logging;
using MossLib.Base;

namespace NightVisionGoggles;

public class ModLocale : ModLocaleBase
{
    // ReSharper disable once UnusedMember.Global
    private static ModLocale Instance { get; set; } = new();
    
    private static ModLocale _instance;
        
    public static void Initialize(ManualLogSource logger)
    {
        if (_instance != null) return;
        _instance = new ModLocale();
        Instance = _instance;
        _instance.Initialize(logger, Plugin.Guid, Plugin.Name, Assembly.GetExecutingAssembly());
    }

    public static string GetFormat(string key, params object[] args) => 
        Instance.GetStringFormatted(key, args);
}