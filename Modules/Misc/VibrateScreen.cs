using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class VibrateScreen : TogglesLoad
    {
        public override void Update()
        {
            if (BVibrateScreen)
            {
                for (int i = 0; i < 10000; i++) 
                {
                    foreach (var Players in Helpers.PlayersList())
                    {
                        Players.tumble.R().GetValue<PhotonView>("photonView", false, false).RPC("TumbleImpactRPC", RpcTarget.Others, Players.photonView.ViewID);
                    }
                }
            }
        }
    }
}
