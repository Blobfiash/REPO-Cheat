using System;
using System.Linq;
using UnityEngine;

namespace SpectralWave.Utill
{
    public class DrawTexture
    {
        /* https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GUI.DrawTexture.html ↓ ↓ ↓ */

        public static void DrawTextureRounded(Rect position, Texture texture, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses)
        => GUI.DrawTexture(position, texture, scaleMode, alphaBlend, imageAspect, color, borderWidths, borderRadiuses);

        public static Rect GetRect(float width, float height, params GUILayoutOption[] options) => GUILayoutUtility.GetRect(width, height, GUIStyle.none, options);

        public static Func<int, int, Color, Texture2D> CreateTex = (width, height, col) =>
        {
            Func<int, Color[]> Pixels = size => Enumerable.Repeat(col, size).ToArray();
            Texture2D tex = new Texture2D(width, height);
            tex.SetPixels(Pixels(width * height));
            tex.Apply();
            return tex;
        };


        /// <summary>
        /// Only using this for changing colors of textures
        /// </summary>
        public static Func<float, float, float, Texture2D> CreateTexture = (r, g, b) =>
        {
            var texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, new Color(r, g, b));
            texture.Apply();
            return texture;
        };


    }
}
