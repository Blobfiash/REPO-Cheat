using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SpectralWave.Utill
{
    public class HarmonyPatches : MonoBehaviour
    {
        public static  Harmony harmony;
        private void Awake()
        {
            harmony = new Harmony("SpectralWaveCheats");
            harmony.PatchAll();
        }
    }
}
