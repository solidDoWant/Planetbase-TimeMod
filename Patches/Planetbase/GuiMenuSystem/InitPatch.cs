using System.Linq;
using Harmony;
using Planetbase;
using PlanetbaseFramework;

namespace Planetbase_TimeMod.Patches.Planetbase.GuiMenuSystem
{
    [HarmonyPatch(typeof(global::Planetbase.GuiMenuSystem))]
    [HarmonyPatch("init")]
    public class InitPatch
    {
        public static bool WasManuallyPaused { get; private set; }

        public static void Postfix(global::Planetbase.GuiMenuSystem __instance)
        {
            var timeManager = Singleton<global::Planetbase.TimeManager>.getInstance();
            var modInstance = ModLoader.GetModByType<TimeMod>().First();
            
            var pauseMenuItem = new GuiMenuItem(
                modInstance.ModTextures.FindTextureWithName("pause button.png"),
                StringList.get("menu_pause"),
                parameter =>
                {
                    if (timeManager.mPaused)
                    {
                        timeManager.unpause();
                        WasManuallyPaused = false;
                    }
                    else
                    {
                        timeManager.pause();
                        WasManuallyPaused = true;
                    }
                }
            );

            var menuSpeed = __instance.mMenuSpeed;

            menuSpeed.mItems.Remove(__instance.mItemSpeedFaster);
            menuSpeed.mItems.Remove(menuSpeed.mBackItem);
            menuSpeed.addItem(pauseMenuItem);
            menuSpeed.addItem(__instance.mItemSpeedFaster);
            menuSpeed.addItem(menuSpeed.mBackItem);
        }
    }
}