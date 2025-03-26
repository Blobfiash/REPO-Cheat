using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SpectralWave.UI
{
    [HarmonyPatch(typeof(PhotonGameLobbyHandler))]
    [HarmonyPatch("OnMasterClientSwitched")]
    public class OnMasterClientSwitchedPatch : MonoBehaviour
    {
        static bool Prefix(Photon.Realtime.Player newMasterClient)
        {
            return false;
        }
    }
}
