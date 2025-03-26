using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using static SpectralWave.ToggleManager.ToggleManager;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;

namespace SpectralWave.Modules.Misc
{
    internal class CrashAll : TogglesLoad
    {
        public override void Update()
        {
            if (!BCrashAll) return;
            PhotonNetwork.NetworkingClient.OpRaiseEvent(207, new Hashtable { { 0, -1 } }, null, SendOptions.SendReliable);
        }
        public static void CrashSelectedPlayer(int Atr)
        {
            PhotonNetwork.NetworkingClient.OpRaiseEvent(207, new Hashtable { { 0, Atr } }, null, SendOptions.SendReliable);
        }
    }
}
