using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Player
{
    internal class InfBattery : TogglesLoad
    {
        public override void Update()
        {
            if (BInfBattery)
            {
                var ItmBattery = PlayerAvatar.instance.physGrabber.grabbed ? PlayerAvatar.instance.physGrabber.R().GetValue<PhysGrabObject>("grabbedPhysGrabObject", false, false)?.GetComponent<ItemEquippable>()?.GetComponent<ItemBattery>() : null;

                ItmBattery?.SetBatteryLife(100);
            }
        }
    }
}
