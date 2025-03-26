using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    [HarmonyPatch]
    public class AntiBreakItems : TogglesLoad
    {
        [HarmonyPatch(typeof(PhysGrabObjectImpactDetector), "OnCollisionStay"), HarmonyPrefix]
        public static bool OnCollisionStay(Collision collision)
        {
            if (BAntiBreakItems) return false;
            return true;
        }
    }
}
