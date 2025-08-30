using UnityEngine;

public class PortaAberta : MonoBehaviour
{
    public GameObject portaFechada;   // Porta visível no início
    public GameObject portaAberta;    // Porta aberta, inicialmente desativada
    public AudioClip somAbrindo;      // Som da porta abrindo
    private AudioSource audioSource;  // Componente de áudio

    void Start()
    {
        // Certifica que a porta aberta começa desativada
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
            Debug.LogWarning("Porta fechada ou aberta não definida!");
        }
    }
}