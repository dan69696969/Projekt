using TMPro;
using UnityEngine;

public class wobble : MonoBehaviour
{
    public TMP_Text textMesh;
    public float waveSpeed = 2f;
    public float waveHeight = 5f;

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

        for (int i = 0; i < characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible)
                continue;

            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            float wave = Mathf.Sin(Time.time * waveSpeed + i * 0.3f) * waveHeight;

            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j].y += wave;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
