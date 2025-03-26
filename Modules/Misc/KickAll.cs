using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using static SpectralWave.TogglesLoadManager.TogglesLoad;

namespace SpectralWave.Modules.Misc
{
    internal class KickAll : TogglesLoad
    {
        public static void Execute()
        {
            if (!PhotonNetwork.LocalPlayer.IsMasterClient)
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            else
                foreach (Photon.Realtime.Player players in PhotonNetwork.PlayerListOthers)
                    PhotonNetwork.SetMasterClient(players);

        }
    }
}
