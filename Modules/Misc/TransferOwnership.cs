using HarmonyLib;
using Photon.Pun;
using SpectralWave.TogglesLoadManager;
using UnityEngine;

namespace SpectralWave.Modules.Misc
{
    internal class TransferOwnership : TogglesLoad
    {
        public static void CallTransferOwnership(int viewID, int playerID) => Traverse.Create(typeof(PhotonNetwork)).Method("TransferOwnership", viewID, playerID).GetValue();

        public static void CallRequestOwnership(int viewID, int fromOwner) => Traverse.Create(typeof(PhotonNetwork)).Method("RequestOwnership", viewID, fromOwner).GetValue();
        public static void TakeAllOwnership()
        {
            int count = 0;
            foreach (PhotonView view in FindObjectsOfType<PhotonView>())
            {
                if (view.Owner.ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
                {

                    CallTransferOwnership(view.ViewID, PhotonNetwork.LocalPlayer.ActorNumber);
                    count++;
                }
            }
            Debug.Log($"Ownership transfer of {count}");
        }
    }
}
