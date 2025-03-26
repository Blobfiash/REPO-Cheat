using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using static SpectralWave.ToggleManager.ToggleManager;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using Photon.Realtime;
using Unity.Mathematics;


namespace SpectralWave.Modules.Misc
{
    internal class KillAll : TogglesLoad
    {
        public static void Execute()
        {
            FindObjectOfType<PlayerHealth>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("HurtOtherRPC", RpcTarget.Others, 20, Vector3.zero, false, 1);
        }
        public static void ExecuteReviveAll()
        {
            foreach (var Players in Helpers.PlayersList())
            {
                if (Players !=null && Players.DeadNot())
                {
                    Players.photonView.RPC("ReviveRPC", RpcTarget.All, false);
                }
            }
        }
        public static void ExecuteHeal()
        {
            FindObjectOfType<PlayerHealth>()?.R().GetValue<PhotonView>("photonView", false).RPC("HealOtherRPC", RpcTarget.Others, 20, true);
            FindObjectOfType<PlayerHealth>()?.R().GetValue<PhotonView>("photonView", false).RPC("HealOtherRPC", RpcTarget.MasterClient, 20, true);
        }
    }
}
