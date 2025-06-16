using TMPro;
using UnityEngine;

public class LastEffect : MonoBehaviour
{
    public TMP_Text textMesh;
    public float pulseSpeed = 2f;
    public float pulseAmount = 1.05f;
    public float shakeMagnitude = 0.5f;
    public float waveSpeed = 3f;
    public float waveHeight = 2f;

    private TMP_TextInfo textInfo;

    void Start()
    {
        if (textMesh == null)
            textMesh = GetComponent<TMP_Text>();

        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        int characterCount = textInfo.characterCount;

        float pulse = Mathf.Sin(Time.time * pulseSpeed) * (pulseAmount - 1f) + 1f;

        for (int i = 0; i < characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            Vector3 center = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2;

            float wave = Mathf.Sin(Time.time * waveSpeed + i * 0.3f) * waveHeight;
            Vector3 shake = new Vector3(
                Random.Range(-shakeMagnitude, shakeMagnitude),
                wave + Random.Range(-shakeMagnitude, shakeMagnitude),
                0);

            for (int j = 0; j < 4; j++)
            {
                Vector3 offset = vertices[vertexIndex + j] - center;
                offset *= pulse;
                vertices[vertexIndex + j] = center + offset + shake;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
