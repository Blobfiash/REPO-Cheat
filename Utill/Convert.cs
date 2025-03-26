using HarmonyLib;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace SpectralWave.Utill
{
    internal class Convert : TogglesLoadManager.TogglesLoad
    {

        /// <summary>
        /// Using this for image loading 
        /// </summary>
        public static Func<string, Texture2D> Con64Texture = s =>
        {
            var tex = new Texture2D(1, 1, TextureFormat.ARGB32, true, true)
            {
                hideFlags = HideFlags.HideAndDontSave,
                filterMode = FilterMode.Bilinear
            };
            tex.LoadImage(System.Convert.FromBase64String(s), true);
            return tex;
        };
    }
}
