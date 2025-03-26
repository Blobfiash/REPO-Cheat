using SpectralWave.Utill;
using System.Collections.Generic;
using UnityEngine;
using static SpectralWave.UI.SpectralUI;

namespace SpectralWave.UI.Managment
{
    public class GUIButtons : MonoBehaviour
    {

        public static void CreateLabel(string text)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label($"<size=18><b>{text}</b></size>");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        public static void CreateBox(string title, System.Action Act)
        {
            Rect BoxRect = new Rect(160f, 50f, 230f, 330f);
            DrawTexture.DrawTextureRounded(BoxRect, BoxTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(6f, 6f, 6f, 6f));

            GUI.Label(new Rect(BoxRect.x + 10f, BoxRect.y + 2, BoxRect.width - 20f, 30f), "<size=16><b>" + title + "</b></size>");

            GUILayout.BeginArea(new Rect(BoxRect.x + 10f, BoxRect.y + 30f, BoxRect.width - 20f, BoxRect.height - 40f));
            Act();
            GUILayout.EndArea();
        }
        public static void CreateRightBox(string title, System.Action Act)
        {
            Rect RightBoxRect = new Rect(400f, 50f, 258f, 330f);
            DrawTexture.DrawTextureRounded(RightBoxRect, BoxTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            GUI.Label(new Rect(RightBoxRect.x + 10f, RightBoxRect.y + 2, RightBoxRect.width - 20f, 30f), "<size=16><b>" + title + "</b></size>");
            GUILayout.BeginArea(new Rect(RightBoxRect.x + 10f, RightBoxRect.y + 30f, RightBoxRect.width - 20f, RightBoxRect.height - 40f));
            Act();
            GUILayout.EndArea();
        }

        /// <summary>
        /// ONLY USING IF THERE IS NO RIGHT BOX 
        /// </summary>
        public static void CreateLeftBox(string title, System.Action Act)
        {
            Rect LeftBoxRect = new Rect(160f, 50f, 340f, 250f);
            DrawTexture.DrawTextureRounded(LeftBoxRect, BoxTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            GUI.Label(new Rect(LeftBoxRect.x + 10f, LeftBoxRect.y + 2, LeftBoxRect.width - 20f, 20f), "<size=16><b>" + title + "</b></size>");
            GUILayout.BeginArea(new Rect(LeftBoxRect.x + 20f, LeftBoxRect.y + 30f, LeftBoxRect.width - 20f, LeftBoxRect.height - 40f));
            if (Act != null) Act();
            GUILayout.EndArea();
        }
        public static bool CreateToggle(bool value, string text)
        {
            GUILayout.BeginHorizontal();
            Rect rect = DrawTexture.GetRect(28, 27, GUILayout.ExpandWidth(false));

            DrawTexture.DrawTextureRounded(rect, value ? normalToggleTexture : activebuttonTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(4f, 4f, 4f, 4f));
            if (value) GUI.Label(new Rect(rect.x + 5, rect.y + 4, 20f, 20f), "X", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontSize = 17 });
            if (GUI.Button(new Rect(rect.x + 5, rect.y + 6f, 25f, 29f), "", GUIStyle.none)) value = !value;
            GUI.Label(new Rect(rect.x + 45, rect.y + 2f, 1000, 24), $"<b>{text}</b>", new GUIStyle(GUI.skin.label) { fontSize = 14, richText = true });

            GUILayout.EndHorizontal();
            GUILayout.Space(3f);
            return value;
        }
        public static void CreateButton(string text, System.Action Act)
        {
            Rect rect = DrawTexture.GetRect(320, 40);
            GUILayout.BeginHorizontal();
            Rect buttonRect = new Rect(rect.x + 3, rect.y + 6f, 75, 25f);
            DrawTexture.DrawTextureRounded(buttonRect, normalbuttonTexture, ScaleMode.StretchToFill, true, 1f, Color.white, Vector4.zero, new Vector4(6, 6, 6, 6));
            if (GUI.Button(buttonRect, "<b>Execute</b>", new GUIStyle { alignment = TextAnchor.MiddleCenter, normal = { textColor = Color.white } })) Act?.Invoke();
            GUI.Label(new Rect(rect.x + 87, rect.y + 7f, 1000, 24), $"<b>{text}</b>");
            GUILayout.EndHorizontal();
            GUILayout.Space(3f);    
        }
        public static void CreateTextField(ref string text, string label)
        {
            GUILayout.BeginHorizontal();
            Rect rect = DrawTexture.GetRect(320, 40);
            GUI.Label(new Rect(rect.x + 5, rect.y + 7f, 100, 20), $"<b>{label}:</b>", new GUIStyle(GUI.skin.label) { fontSize = 14 });
            text = GUI.TextField(new Rect(rect.x + 110f, rect.y + 7f, 180f, 25f), text, 100, new GUIStyle(GUI.skin.textField)
            {
                fontSize = 14,
                alignment = TextAnchor.MiddleLeft
            });

            GUILayout.EndHorizontal();
            GUILayout.Space(5f);
        }

        public static float SlideWidth = 200;
        public static void CreateSlider(ref float value, float minValue, float maxValue, string label)
        {
            float w = 120f, f = w * (value - minValue) / (maxValue - minValue);
            Rect r = DrawTexture.GetRect(320, 40);
            DrawTexture.DrawTextureRounded(new Rect(r.x + 5, r.y + 7f, w, 12), SliderTexture, ScaleMode.StretchToFill, true, 1, Color.white, Vector4.zero, new Vector4(6, 6, 6, 6));
            DrawTexture.DrawTextureRounded(new Rect(r.x + 5 + Mathf.Clamp(f - 6, 0, w - 12), r.y + 7f + 4, 12, 4), SliderBcTexture, ScaleMode.StretchToFill, true, 1, Color.white, Vector4.zero, new Vector4(3f, 3f, 3f, 3f));
            value = GUI.HorizontalSlider(new Rect(r.x + 5, r.y + 7f, w, 10f), value, minValue, maxValue, GUIStyle.none, GUIStyle.none);
            GUI.Label(new Rect(r.x + w + 19, r.y + 7f, 100, 20), $"<b>{label}: {Mathf.Round(value)}</b>", new GUIStyle(GUI.skin.label) { fontSize = 14 });
            GUILayout.Space(2f);
        }
    }
}
