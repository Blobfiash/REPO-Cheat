using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Visual
{
    internal class EspManager : TogglesLoad
    {
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        public static void OnGUI()
        {
            if (!BEnableEsp) return;
            if (BBoxEsp)
            {
            }
        }

    }
}
