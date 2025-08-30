using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textoUI; // arraste o seu TMP_Text aqui
    [TextArea] public string textoCompleto; // o texto que vai aparecer

    [Header("Configura��o")]
    public float velocidade = 0.05f; // tempo entre cada letra
    public AudioSource audioSource; // arraste o AudioSource aqui
    public AudioClip somLetra; // som para cada letra

    private bool dialogoAtivo = false; // controla se o di�logo est� ativo

    private void Start()
    {
        textoUI.text = ""; // come�a vazio
        ComecarDialogo(); // inicia o di�logo sozinho
    }

    public void ComecarDialogo()
    {
        StopAllCoroutines(); // evita bugs se clicar v�rias vezes
        StartCoroutine(MostrarTexto());
    }

    private System.Collections.IEnumerator MostrarTexto()
    {
        dialogoAtivo = true; // di�logo come�ou
        textoUI.text = "";

        // Configura o AudioSource para repetir o som continuamente
        if (audioSource != null && somLetra != null)
        {
            audioSource.clip = somLetra;
            audioSource.loop = true; // habilita loop
            audioSource.Play();
        }

        foreach (char letra in textoCompleto.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidade);
        }

        dialogoAtivo = false; // di�logo terminou

        // Para o �udio quando o di�logo acabar
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.loop = false; // desativa loop para a pr�xima vez
        }
    }
}