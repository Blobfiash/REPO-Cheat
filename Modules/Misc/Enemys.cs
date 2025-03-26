using Photon.Pun;
using Photon.Voice.PUN.UtilityScripts;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using System.Linq;
using UnityEngine;
using UnityMeshSimplifier;
using static SpectralWave.ToggleManager.ToggleManager;


namespace SpectralWave.Modules.Misc
{
    internal class Enemys : TogglesLoad
    {
        public override void Update()
        {
          EnemyDirector.instance?.R().SetValue("debugNoVision", BEnemiesCantSee);
        }
        public static void ExecuteFreeze()
        {
            FindObjectOfType<Enemy>()?.R().GetValue<PhotonView>("PhotonView", false)?.RPC("FreezeRPC", RpcTarget.All, FreezeAllTime);
            FindObjectOfType<Enemy>()?.R().GetValue<PhotonView>("PhotonView", false)?.RPC("FreezeRPC", RpcTarget.MasterClient, FreezeAllTime);
        }
        public static void ExecuteKillAll()
        {
            FindObjectsOfType<EnemyHealth>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("HurtRPC", RpcTarget.All, 100, Vector3.zero);
        }
    }
}
