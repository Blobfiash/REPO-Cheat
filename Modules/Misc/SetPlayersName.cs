using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;

namespace SpectralWave.Modules.Misc
{
    internal class SetPlayersName : TogglesLoad
    {
        public static void Execute()
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                if (player != PhotonNetwork.LocalPlayer)
                    player.NickName = "JUADF";
            }
            foreach (var Players in GameDirector.instance.PlayerList)
            {
                FindObjectOfType<PlayerAvatar>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("AddToStatsManagerRPC", RpcTarget.All, "JUADF", SemiFunc.PlayerGetSteamID(Players));
                
            }
        }
    }
}
