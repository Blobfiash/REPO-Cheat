using static SpectralWave.ToggleManager.ToggleManager;
using System.Reflection;
using SpectralWave.TogglesLoadManager;
using UnityEngine;
using HarmonyLib;
using SpectralWave.Utill;

namespace SpectralWave.Modules.Player
{
    internal class GodMode : TogglesLoad
    {

        public override void Update()
        {
            PlayerAvatar.instance.playerHealth.R().SetValue("godMode", false);
            if (!BGodMode) return;
            PlayerAvatar.instance.playerHealth.R().SetValue("godMode", true);
        }
    }
}
