using UnityEngine;

public class PortaAberta : MonoBehaviour
{
    public GameObject portaFechada;   // Porta vis�vel no in�cio
    public GameObject portaAberta;    // Porta aberta, inicialmente desativada
    public AudioClip somAbrindo;      // Som da porta abrindo
    private AudioSource audioSource;  // Componente de �udio

    void Start()
    {
        // Certifica que a porta aberta come�a desativada
        if (portaAberta != null)
            portaAberta.SetActive(false);

        // Pega ou adiciona um AudioSource no mesmo objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void AbrirPorta()
    {
        if (portaFechada != null && portaAberta != null)
        {
            // Toca o som da porta abrindo
            if (somAbrindo != null && audioSource != null)
                audioSource.PlayOneShot(somAbrindo);

            // Troca a porta fechada pela aberta
            portaFechada.SetActive(false);
            portaAberta.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Porta fechada ou aberta n�o definida!");
        }
    }
}