using HarmonyLib;

class HarmonyCore : GameModification
{
    Harmony _harmony;

    public HarmonyCore(Mod p_mod) : base(p_mod)
    {
        p_mod.Log("Registering...");
    }

    public override void OnModInitialization(Mod p_mod)
    {
        mod = p_mod;

        mod.Log("Initializing...");

        PatchGame();
    }

    public override void OnModUnloaded()
    {
        mod.Log("Unloading...");

        _harmony?.UnpatchAll(_harmony.Id);
    }

    void PatchGame()
    {
        mod.Log("Patching...");

        _harmony = new Harmony("com.hexofsteel.harmonycore");
        _harmony.PatchAll();
    }
}