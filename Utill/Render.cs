using System;
using UnityEngine;

namespace SpectralWave.Utill
{
    public class Render : MonoBehaviour
    {

        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        public static Color Color { get { return GUI.color; } set { GUI.color = value; } }

        public static Func<Vector2, Vector2, Color, bool, Vector2> DrawBox = (position, size, color, centered) =>
        {
            GUI.color = color;
            Vector2 vector = centered ? (position - size / 2f) : position;
            GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, 0);
            return vector;
        };

        public static void DrawBoxs(float x, float y, float w, float h, Color color, float thickness)
        {
            Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
            Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
            Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
            Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
        }

        public static Func<Vector2, string, Color, bool, Vector2> DrawString = (position, label, color, centered) =>
        {
            GUI.color = color;
            GUIContent content = new GUIContent(label);
            Vector2 vector = StringStyle.CalcSize(content);
            position = centered ? (position - vector / 2f) : position;
            GUI.Label(new Rect(position, vector), content);
            return position;
        };

        public static Func<Vector2, float, float, Color, Vector2> Circle = (center, radius, thickness, color) =>
        {
            GUI.color = color;
            Vector2 from = center + new Vector2(radius, 0f);
            for (int i = 1; i <= 360; i++)
            {
                float f = Mathf.Deg2Rad * i;
                Vector2 vector = center + new Vector2(radius * Mathf.Cos(f), radius * Mathf.Sin(f));
                Line(from, vector, thickness);
                from = vector;
            }
            return center;
        };

        public static Func<Vector2, Vector2, float, Vector2> Line = (from, to, thickness) =>
        {
            Vector2 normalized = (to - from).normalized;
            float num = Mathf.Atan2(normalized.y, normalized.x) * Mathf.Rad2Deg;
            GUIUtility.RotateAroundPivot(num, from);
            Box(from, Vector2.right * (from - to).magnitude, thickness, false);
            GUIUtility.RotateAroundPivot(-num, from);
            return from;
        };

        public static Func<Vector2, Vector2, float, bool, Vector2> Box = (position, size, thickness, centered) =>
        {
            if (centered) position -= size / 2f;
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
            return position;
        };

        private static Texture2D lineTex;
        public static Func<Vector2, Vector2, Color, float, Vector2> DrawLine = (pointA, pointB, color, width) =>
        {
            if (lineTex == null) lineTex = new Texture2D(1, 1);
            Color prevColor = GUI.color;
            GUI.color = color;
            float angle = Vector3.Angle(pointB - pointA, Vector2.right);
            if (pointA.y > pointB.y) angle = -angle;
            GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), pointA);
            GUIUtility.RotateAroundPivot(angle, pointA);
            GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
            GUI.color = prevColor;
            return pointA;
        };

        public static Func<Vector2, string, Color, float, bool, Vector2> DrawColorString = (position, label, color, size, centered) =>
        {
            GUIStyle style = new GUIStyle { fontSize = Mathf.RoundToInt(size), normal = { textColor = color } };
            Vector2 vector = style.CalcSize(new GUIContent(label));
            GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), label, style);
            return position;
        };
    }
}
