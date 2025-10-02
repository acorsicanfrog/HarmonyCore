using HarmonyLib;
using UnityEngine;

class HarmonyCore : GameModification
{
    Harmony _harmony;

    public HarmonyCore(Mod p_mod) : base(p_mod)
    {
        Debug.Log($"[MOD:{p_mod.name}] Registering...");
    }

    public override void OnModInitialization(Mod p_mod)
    {
        mod = p_mod;

        Debug.Log($"[MOD:{mod.name}] Initializing...");

        PatchGame();
    }

    public override void OnModUnloaded()
    {
        Debug.Log($"[MOD:{mod.name}] Unloading...");

        _harmony?.UnpatchAll(_harmony.Id);
    }

    void PatchGame()
    {
        Debug.Log($"[MOD:{mod.name}] Patching...");

        _harmony = new Harmony("com.hexofsteel.harmonycore");
        _harmony.PatchAll();
    }
}