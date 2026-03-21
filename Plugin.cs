using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MossLib;

namespace NightVisionGoggles;

[BepInPlugin(Guid, Name, "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    // ReSharper disable once MemberCanBePrivate.Global
    internal new static ManualLogSource Logger;
    internal const string Guid = "blackmoss.nightvisiongoggles";
    internal const string Name = "Night Vision Goggles";
    private readonly Harmony _harmony = new(Guid);
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public static Plugin Instance { get; private set; } = null!;

    public void Awake()
    {
        Logger = base.Logger;
        Instance = this;
        _harmony.PatchAll();
        ModLocale.Initialize(Logger);
    }
    
    [HarmonyPatch(typeof(PlayerCamera), "HandleScreenShaders")]
    private static class PlayerCameraHandleScreenShadersPatch
    {
        private static void Postfix(PlayerCamera __instance)
        {
            var item = __instance.body.GetWearableBySlotID("eyes");
            if (item != null && item.id == "autozoomgoggles")
            {
                __instance.blindLight?.SetActive(true);
            }
        }
    }
}