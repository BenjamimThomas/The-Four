using UnityEngine;
using TMPro; // só se estiver usando TextMeshPro
using UnityEngine.UI; // se usar Text normal
public class Diálogo : MonoBehaviour
{
    public TMP_Text textoUI; // arraste o seu TMP_Text aqui
    public string textoCompleto; // o texto que vai aparecer
    public float velocidade = 0.05f; // tempo entre cada letra

    private void Start()
    {
        textoUI.text = ""; // começa vazio
        ComecarDialogo(); // inicia o dialogo sozinho
    }

    public void ComecarDialogo()
    {
        StopAllCoroutines(); // evita bugs se clicar várias vezes
        StartCoroutine(MostrarTexto());
    }

    private System.Collections.IEnumerator MostrarTexto()
    {
        textoUI.text = "";
        foreach (char letra in textoCompleto.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidade);
        }
    }
}
