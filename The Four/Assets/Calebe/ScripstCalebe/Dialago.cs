using UnityEngine;
using TMPro; // só se estiver usando TextMeshPro
using UnityEngine.UI; // se usar Text normal
public class TipoTexto : MonoBehaviour
{
    public TMP_Text textoUI; 
    public string textoCompleto; 
    public float velocidade = 0.05f; 
    private void Start()

    {
        textoUI.text = "";
    }
    public void ComecarDialogo()
    {
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

