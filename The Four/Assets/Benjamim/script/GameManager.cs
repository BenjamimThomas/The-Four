using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;



public class GameManager : MonoBehaviour
{
    [Header("Referências")]
    public GameObject alvoPrefab;
    public Transform canvas;      // Canvas (RectTransform)
    public TMP_Text scoreText;
    public TMP_Text vidasText;
    public TMP_Text gameOverText;
    public Image erroFlash;

    [Header("Regras")]
    public float tempoLimite = 2f;     // tempo para clicar no alvo
    public int vidasIniciais = 3;      // vidas
    public float spawnAnimDuration = 0.2f; // duração da animação de aparecer

    [Header("Limites de spawn (margem)")]
    public Vector2 margem = new Vector2(20f, 20f); // margem da borda da tela

    private int score = 0;
    private int vidas;
    private GameObject alvoAtual;
    private Coroutine tempoCoroutine;

    void Start()
    {
        vidas = vidasIniciais;
        scoreText.text = "Acertos: 0";
        vidasText.text = "Vidas: " + vidas;
        gameOverText.gameObject.SetActive(false);

        SpawnAlvo();
    }

    void SpawnAlvo()
    {
        if (vidas <= 0) return;

        if (alvoAtual != null) Destroy(alvoAtual);

        alvoAtual = Instantiate(alvoPrefab, canvas);

        // posição aleatória segura dentro do Canvas
        RectTransform canvasRT = canvas as RectTransform;
        RectTransform rt = alvoAtual.GetComponent<RectTransform>();

        Vector2 canvasSize = canvasRT.rect.size;
        Vector2 alvoSize = rt.sizeDelta;

        float xMin = -canvasSize.x / 2f + alvoSize.x / 2f + margem.x;
        float xMax = canvasSize.x / 2f - alvoSize.x / 2f - margem.x;
        float yMin = -canvasSize.y / 2f + alvoSize.y / 2f + margem.y;
        float yMax = canvasSize.y / 2f - alvoSize.y / 2f - margem.y;

        rt.anchoredPosition = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        var alvoScript = alvoAtual.GetComponent<Alvo>();
        alvoScript.OnClick += () =>
        {
            score++;
            scoreText.text = "Acertos: " + score;

            if (tempoCoroutine != null) StopCoroutine(tempoCoroutine);
            SpawnAlvo();
        };

        // anima o aparecer
        alvoScript.Aparecer(spawnAnimDuration, 1f);

        // inicia o cronômetro de reação
        tempoCoroutine = StartCoroutine(TempoDeReacao());
    }

    IEnumerator TempoDeReacao()
    {
        yield return new WaitForSeconds(tempoLimite);

        if (alvoAtual != null)
        {
            Destroy(alvoAtual);
            PerderVida();
        }
    }
    IEnumerator FlashErro()
    {
        erroFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        erroFlash.gameObject.SetActive(false);
    }

    void PerderVida()
    {
        vidas--;
        vidasText.text = "Vidas: " + vidas;
        StartCoroutine(FlashErro());

        if (vidas > 0)
        {
            SpawnAlvo();
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "GAME OVER\nPontuação: " + score;
    }
}