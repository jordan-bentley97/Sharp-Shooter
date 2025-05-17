using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class RainbowTextEffect : MonoBehaviour
{
    public float speed = 1f;
    public float hueShiftPerCharacter = 0.1f;

    private TMP_Text textComponent;
    private TMP_TextInfo textInfo;
    private Color32[] newVertexColors;

    void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textComponent.ForceMeshUpdate(); // Make sure mesh is updated
        textInfo = textComponent.textInfo;

        float time = Time.time * speed;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible) continue;

            int meshIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            var vertices = textInfo.meshInfo[meshIndex].vertices;
            var colors = textInfo.meshInfo[meshIndex].colors32;

            float hue = Mathf.Repeat(time + i * hueShiftPerCharacter, 1f);
            Color32 color = Color.HSVToRGB(hue, 1f, 1f);

            colors[vertexIndex + 0] = color;
            colors[vertexIndex + 1] = color;
            colors[vertexIndex + 2] = color;
            colors[vertexIndex + 3] = color;
        }

        // Push the updated vertex colors to the mesh
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
            textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}