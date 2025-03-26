using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;

namespace SpectralWave.Modules.Misc
{
    internal class Players : TogglesLoad
    {
        public static void ExecutePlayerShortAll()
        {
            foreach (var Players in Helpers.PlayersList())
            {
                Players.tumble.R().GetValue<PhotonView>("photonView", false, false).RPC("TumbleImpactRPC", RpcTarget.All, Players.photonView.ViewID);
                Players.tumble.R().GetValue<PhotonView>("photonView", false, false).RPC("TumbleImpactRPC", RpcTarget.Others, Players.photonView.ViewID);
                Players.tumble.R().GetValue<PhotonView>("photonView", false, false).RPC("TumbleImpactRPC", RpcTarget.MasterClient, Players.photonView.ViewID);
            }
        }
        public static void MakePlayerSayThis(string This, PlayerAvatar Selected)
        {
            Selected.ChatMessageSendRPC(This, false);
            Selected.ChatMessageSend(This, false);
            Selected.photonView.RPC("ChatMessageSendRPC", Selected.photonView.Owner, This, false);
        }
        public static void ExecuteRestartScene() => RunManager.instance.RestartScene();
        
        public static void BreakSelectedPlayerItem(PlayerAvatar selected)
        {
            var ImpDtc = selected?.physGrabber?.R()?.GetValue<PhysGrabObject>("grabbedPhysGrabObject")?.GetComponent<PhysGrabObjectImpactDetector>() ?? selected?.physGrabber?.R()?.GetValue<PhysGrabObject>("grabbedPhysGrabObject")?.GetComponentInChildren<PhysGrabObjectImpactDetector>() ?? selected?.physGrabber?.R()?.GetValue<PhysGrabObject>("grabbedPhysGrabObject")?.GetComponentInParent<PhysGrabObjectImpactDetector>();

            if (ImpDtc is null) return;
            ImpDtc?.R()?.GetValue<PhotonView>("photonView")?.RPC("DestroyObjectRPC", RpcTarget.All, true);

        }
    }
}
