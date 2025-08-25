using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Alvo : MonoBehaviour
{
    public Action OnClick;

    private RectTransform rt;
    private Button btn;
    private Coroutine anim;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        btn = GetComponent<Button>();
    }

    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            OnClick?.Invoke();
            
        });
    }

    // Chame esta fun��o logo ap�s instanciar para tocar a anima��o de spawn
    public void Aparecer(float duracao = 0.2f, float escalaFinal = 1f)
    {
        if (anim != null) StopCoroutine(anim);
        rt.localScale = Vector3.zero; // come�a pequeno
        anim = StartCoroutine(AnimScale(Vector3.zero, Vector3.one * escalaFinal, duracao));
    }

    IEnumerator ClickPopAndDestroy()
    {
        // pop r�pido
        yield return AnimScale(rt.localScale, Vector3.one * 1.15f, 0.06f);
        // encolhe e destr�i
        yield return AnimScale(rt.localScale, Vector3.zero, 0.08f);
        Destroy(gameObject);
    }

    IEnumerator AnimScale(Vector3 from, Vector3 to, float dur)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime / Mathf.Max(0.0001f, dur);
            float s = Smooth(t); // suaviza��o
            rt.localScale = Vector3.LerpUnclamped(from, to, s);
            yield return null;
        }
        rt.localScale = to;
    }

    // Smoothstep
    float Smooth(float x) => x * x * (3f - 2f * x);
}