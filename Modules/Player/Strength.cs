using SpectralWave.TogglesLoadManager;
using System.Reflection;
using System;
using static SpectralWave.ToggleManager.ToggleManager;
using Steamworks;
using HarmonyLib;
using SpectralWave.Utill;
using Photon.Realtime;

namespace SpectralWave.Modules.Player
{
    internal class Strength : TogglesLoad
    {
        public static void Execute()
        {
            for  (int i = 0; i < 5; i++)
                    PunManager.instance.UpgradePlayerGrabStrength(SemiFunc.PlayerGetSteamID(PlayerAvatar.instance));
        }
    }
}
