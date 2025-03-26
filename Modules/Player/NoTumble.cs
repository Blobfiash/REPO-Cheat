using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class NoTumble : TogglesLoad
    {
        public override void Update()
        {
            PlayerController.instance.DebugNoTumble = BNoTumble;
            if (BNoTumble) PlayerController.instance.R().SetValue("DebugNoTumble", true);
            else PlayerController.instance.R().SetValue("DebugNoTumble", false);
        }
    }
}
