using Photon.Pun;
using SpectralWave.Modules.Player;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using System.Linq;

namespace SpectralWave.Modules.Misc
{
    internal class SetScreenText : TogglesLoad
    {
        public static void Execute()
        {
            var thing = string.Join(" ", Enumerable.Repeat("LOW TAPER FADE LOW TAPER FADE", 1000));
                foreach (var Player in GameDirector.instance.PlayerList)
                {
                    Player.ChatMessageSend(thing, false);
                    FindObjectOfType<PlayerAvatar>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("ChatMessageSendRPC", RpcTarget.All, thing, false);
                }
        }
        public static void ExecuteTaxManText()
        {
            TruckScreenText.instance.MessageSendCustomRPC("", "SPECTRALWAVE MENU");

            FindObjectOfType<TruckScreenText>()?.R().GetValue<PhotonView>("photonView", false).RPC("MessageSendCustomRPC", RpcTarget.MasterClient, "", "SPECTRALWAVE MENU");
        }

    }
}