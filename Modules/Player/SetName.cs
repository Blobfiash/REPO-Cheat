using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using Steamworks;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SpectralWave.Modules.Player
{
    internal class SetName : TogglesLoad
    {
        public static string SuperSize = "<color=purple><size=10>" + string.Concat(Enumerable.Repeat("SPECTRALWAVE ", 1000)) + "</size>";
        public static string Normal = string.Concat(Enumerable.Repeat("SPECTRALWAVE ", 900));
        public static string Name; /*   Later Unc   */ 
        public static void Execute()
        {                                                       
            PhotonNetwork.LocalPlayer.NickName = SuperSize;
            PlayerAvatar.instance.photonView.RPC("AddToStatsManagerRPC", RpcTarget.All, SuperSize, SemiFunc.PlayerGetSteamID(PlayerAvatar.instance));
        }
        public static void ExecuteResetName()
        {
            PhotonNetwork.LocalPlayer.NickName = SteamClient.Name;
            PlayerAvatar.instance.photonView.RPC("AddToStatsManagerRPC", RpcTarget.All, SteamClient.Name, SemiFunc.PlayerGetSteamID(PlayerAvatar.instance));
        }
    }
}
