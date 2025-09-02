using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContagemRegressiva : MonoBehaviour
{
    public TMP_Text textoContagem;
    public Image fundoPreto;
    public string nomeCena;
    public AudioSource audioClique;
    private bool emContagem = false;

    public void IniciarContagem()
    {
        if (!emContagem)
        {
            if (audioClique != null)
                audioClique.Play();
            StartCoroutine(ExecutarContagem());
        }
    }

    private IEnumerator ExecutarContagem()
    {
        emContagem = true;

        for (int i = 3; i > 0; i--)
        {
            textoContagem.text = i.ToString();
            textoContagem.fontSize = 60;
            yield return StartCoroutine(AnimarNumero());
            yield return new WaitForSeconds(0.5f);
        }

        textoContagem.text = "Está na hora";
        yield return new WaitForSeconds(1f);

        fundoPreto.gameObject.SetActive(true);
        fundoPreto.color = new Color(0, 0, 0, 0);

        for (float a = 0; a <= 1f; a += 0.02f)
        {
            fundoPreto.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.02f);
        }

        SceneManager.LoadScene(nomeCena);
    }

    private IEnumerator AnimarNumero()
    {
        for (float tamanho = 60; tamanho <= 80; tamanho += 5)
        {
            textoContagem.fontSize = tamanho;
            yield return new WaitForSeconds(0.02f);
        }
        for (float tamanho = 80; tamanho >= 60; tamanho -= 5)
        {
            textoContagem.fontSize = tamanho;
            yield return new WaitForSeconds(0.02f);
        }
    }
}