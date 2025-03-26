using Photon.Pun;
using SpectralWave.Utill;
using UnityEngine;
namespace SpectralWave.Modules.Misc
{
    public class CompleteExtro
    {
        public static void CompleteAllExtroPoints()
        {
            Object.FindObjectOfType<ExtractionPoint>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("StateSetRPC", RpcTarget.All, ExtractionPoint.State.Complete);
            Object.FindObjectOfType<ExtractionPoint>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("StateSetRPC", RpcTarget.MasterClient, ExtractionPoint.State.Complete);
        }
    }
}
