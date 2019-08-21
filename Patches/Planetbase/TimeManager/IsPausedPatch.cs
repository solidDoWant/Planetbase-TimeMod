using System.Linq;
using Harmony;
using Planetbase_TimeMod.Patches.Planetbase.GuiMenuSystem;
using PlanetbaseFramework;

namespace Planetbase_TimeMod.Patches.Planetbase.TimeManager
{
    [HarmonyPatch(typeof(global::Planetbase.TimeManager))]
    [HarmonyPatch("isPaused")]
    public class IsPausedPatch
    {
        private static readonly bool ShouldPatch = ModLoader.GetModByType<TimeMod>().First().ShouldOverrideTimeManagerIsPaused;

        public static bool Postfix(bool __result)
        {
            if (ShouldPatch)
                return __result && !InitPatch.WasManuallyPaused;

            return __result;
        }
    }
}