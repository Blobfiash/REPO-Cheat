using HarmonyLib;
using SpectralWave.TogglesLoadManager;
using SpectralWave.UI;
using SpectralWave.Utill;
using System.Reflection;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class InfStamina : TogglesLoad
    {
        public override void Update()
        {
            if (BInfStamina) PlayerController.instance.DebugEnergy = true;
            
           
        }
    }
}