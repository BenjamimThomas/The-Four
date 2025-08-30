using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicaMenu : MonoBehaviour
{
    public AudioSource musica;       // arraste seu AudioSource aqui
    public Button botao;             // arraste o bot�o aqui
    public Image imagemBotao;        // arraste o componente Image do bot�o aqui
    public Sprite spriteSomLigado;   // sprite quando o som est� ligado
    public Sprite spriteSomMutado;   // sprite quando o som est� mutado

    private bool mutado = false;

    void Start()
    {
        botao.onClick.AddListener(ToggleMute);
        AtualizarBotao();
    }

    void ToggleMute()
    {
        mutado = !mutado;        // inverte o estado
        musica.mute = mutado;    // aplica no AudioSource
        AtualizarBotao();
    }

    void AtualizarBotao()
    {
        if (imagemBotao != null)
        {
            imagemBotao.sprite = mutado ? spriteSomMutado : spriteSomLigado;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}