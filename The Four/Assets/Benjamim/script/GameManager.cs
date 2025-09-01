using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Referências")]
    public GameObject alvoPrefab;
    public Transform canvas;
    public TMP_Text scoreText;
    public TMP_Text vidasText;
    public TMP_Text gameOverText;
    public Image erroFlash;

    [Header("Regras")]
    public float tempoLimite = 2f;
    public int vidasIniciais = 3;
    public float spawnAnimDuration = 0.2f;

    [Header("Limites de spawn (margem)")]
    public Vector2 margem = new Vector2(20f, 20f);

    [Header("Sons")]
    public AudioSource audioSource;   // arraste um AudioSource no Inspector
    public AudioClip somAcerto;       // som quando acertar
    public AudioClip somErro;         // som quando errar
    public AudioClip somGameOver;     // som quando acabar o jogo

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

            // toca som de acerto
            if (audioSource && somAcerto) audioSource.PlayOneShot(somAcerto);

            if (tempoCoroutine != null) StopCoroutine(tempoCoroutine);
            SpawnAlvo();
        };

        alvoScript.Aparecer(spawnAnimDuration, 1f);

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

        // toca som de erro
        if (audioSource && somErro) audioSource.PlayOneShot(somErro);

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

        // toca som de game over
        if (audioSource && somGameOver) audioSource.PlayOneShot(somGameOver);
    }
}
