using PlanetbaseFramework;

namespace Planetbase_TimeMod
{
    public class TimeMod : ModBase
    {
        /// <summary>
        /// Modders - if you want this mod to NOT patch the TimeManager::isPaused() method, set this to false for default behavior.
        /// </summary>
        public bool ShouldOverrideTimeManagerIsPaused { get; set; } = true;

        public override string ModName { get; } = "TimeMod";

        public override void Init()
        {
            InjectPatches();
        }
    }
}
