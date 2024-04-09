using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApollosScripts
{
    public static class ApoCLs
    {
        public static TextMesh CreateWorldText(string text, Transform parent, Vector3 localPosition, int frontSize, Color color)
        {
            GameObject textObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = textObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = textObject.GetComponent<TextMesh>();
            textMesh.text = text;
            textMesh.color = color;
            textMesh.fontSize = frontSize;
            textMesh.anchor = TextAnchor.UpperLeft;
            textMesh.alignment= TextAlignment.Left;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = 5000;
            return textMesh;
        }

        public static TextMesh CreateWorldText(string text, Vector3 localPosition, int frontSize = 40, Transform parent = null)
        {
            return CreateWorldText(text, parent, localPosition, frontSize, Color.white);
        }
    }
}