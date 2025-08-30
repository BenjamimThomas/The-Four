using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BotaoStart : MonoBehaviour
{
    public string Game;
    public float delayEmSegundos = 1f; // define o delay antes de ir para a cena

    void Start()
    {
        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(() => StartCoroutine(IrParaCenaGameComDelay()));
    }

    private IEnumerator IrParaCenaGameComDelay()
    {
        // Espera o tempo definido
        yield return new WaitForSeconds(delayEmSegundos);

        // Carrega a cena
        SceneManager.LoadScene(Game);
    }
}