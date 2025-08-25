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

    // Chame esta função logo após instanciar para tocar a animação de spawn
    public void Aparecer(float duracao = 0.2f, float escalaFinal = 1f)
    {
        if (anim != null) StopCoroutine(anim);
        rt.localScale = Vector3.zero; // começa pequeno
        anim = StartCoroutine(AnimScale(Vector3.zero, Vector3.one * escalaFinal, duracao));
    }

    IEnumerator ClickPopAndDestroy()
    {
        // pop rápido
        yield return AnimScale(rt.localScale, Vector3.one * 1.15f, 0.06f);
        // encolhe e destrói
        yield return AnimScale(rt.localScale, Vector3.zero, 0.08f);
        Destroy(gameObject);
    }

    IEnumerator AnimScale(Vector3 from, Vector3 to, float dur)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime / Mathf.Max(0.0001f, dur);
            float s = Smooth(t); // suavização
            rt.localScale = Vector3.LerpUnclamped(from, to, s);
            yield return null;
        }
        rt.localScale = to;
    }

    // Smoothstep
    float Smooth(float x) => x * x * (3f - 2f * x);
}