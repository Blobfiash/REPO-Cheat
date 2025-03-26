using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class SpeedBoost : TogglesLoad
    {
        public override void Update()
        {
            if (BSpeedBoost) PlayerController.instance.SprintSpeed = 6f; 

        }
    }
}
