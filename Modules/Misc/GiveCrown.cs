
using Photon.Pun;
using SpectralWave.Utill;
using System.Collections.Generic;
using UnityEngine;

namespace SpectralWave.Modules.Misc
{
    internal class GiveCrown : TogglesLoadManager.TogglesLoad
    {
        public static void Execute()
        {
            FindObjectOfType<PunManager>()?.R().GetValue<PhotonView>("photonView", false).RPC("CrownPlayerRPC", RpcTarget.All, Helpers.PlayerGetSteamID(PlayerAvatar.instance));
            FindObjectOfType<PunManager>()?.R().GetValue<PhotonView>("photonView", false).RPC("CrownPlayerRPC", RpcTarget.AllBuffered, Helpers.PlayerGetSteamID(PlayerAvatar.instance));
            FindObjectOfType<PunManager>()?.R().GetValue<PhotonView>("photonView", false).RPC("CrownPlayerRPC", RpcTarget.MasterClient, Helpers.PlayerGetSteamID(PlayerAvatar.instance));
            FindObjectOfType<PunManager>()?.R().GetValue<PhotonView>("photonView", false).RPC("CrownPlayerRPC", RpcTarget.Others, Helpers.PlayerGetSteamID(PlayerAvatar.instance));
        }
    }

}
