using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicaMenu : MonoBehaviour
{
    public AudioSource musica;       // arraste seu AudioSource aqui
    public Button botao;             // arraste o botão aqui
    public Image imagemBotao;        // arraste o componente Image do botão aqui
    public Sprite spriteSomLigado;   // sprite quando o som está ligado
    public Sprite spriteSomMutado;   // sprite quando o som está mutado

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