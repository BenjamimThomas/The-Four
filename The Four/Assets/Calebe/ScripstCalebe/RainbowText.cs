using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float speed = 3f; // velocidade da mudança

    void Update()
    {
        // gera cor animada baseado no tempo
        float r = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
        float g = Mathf.Sin(Time.time * speed + 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin(Time.time * speed + 4f) * 0.5f + 0.5f;

        textMeshPro.color = new Color(r, g, b);
    }
}