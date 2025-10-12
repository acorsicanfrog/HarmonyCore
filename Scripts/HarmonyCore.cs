using HarmonyLib;

class HarmonyCore : GameModification
{
    Harmony _harmony;

    public HarmonyCore(Mod p_mod) : base(p_mod)
    {
        Log("Registering...");
    }

    public override void OnModInitialization(Mod p_mod)
    {
        Log("Initializing...");

        PatchGame();
    }

    public override void OnModUnloaded()
    {
        Log("Unloading...");

        _harmony?.UnpatchAll(_harmony.Id);
    }

    void PatchGame()
    {
        Log("Patching...");

        _harmony = new Harmony("com.hexofsteel.harmonycore");
        _harmony.PatchAll();
    }
}