using TMPro;
using UnityEngine;

public class CrazyTextEffect : MonoBehaviour
{
    public TMP_Text textMesh;
    public float waveSpeed = 6f;
    public float waveHeight = 10f;
    public float rotationSpeed = 30f;
    public float colorSpeed = 2f;

    private TMP_TextInfo textInfo;
    private Color[] rainbowColors;

    void Start()
    {
        if (textMesh == null)
            textMesh = GetComponent<TMP_Text>();

        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        rainbowColors = new Color[]
        {
            Color.red, Color.magenta, Color.yellow, Color.green, Color.cyan, Color.blue
        };
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        int characterCount = textInfo.characterCount;

        for (int i = 0; i < characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;
            Color32[] colors = textInfo.meshInfo[materialIndex].colors32;

            // Vlnění
            float wave = Mathf.Sin(Time.time * waveSpeed + i * 0.5f) * waveHeight;

            // Rotace každého znaku
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * rotationSpeed + i) * 30f);

            Vector3 charMidBaseline = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2;
            for (int j = 0; j < 4; j++)
            {
                Vector3 offset = vertices[vertexIndex + j] - charMidBaseline;
                offset.y += wave;
                offset = rotation * offset;
                vertices[vertexIndex + j] = charMidBaseline + offset;
            }

            // RAINBOW VÝBUCH 🌈🔥
            Color rainbowColor = rainbowColors[(int)(Time.time * colorSpeed + i) % rainbowColors.Length];
            for (int j = 0; j < 4; j++)
            {
                colors[vertexIndex + j] = rainbowColor;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
