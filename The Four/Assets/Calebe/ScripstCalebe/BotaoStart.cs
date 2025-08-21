using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotaoStart
    : MonoBehaviour
{
    
    public string Game;

    void Start()
    {
      
        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(IrParaCenaGame);
    }

    public void IrParaCenaGame()
    {
        SceneManager.LoadScene(Game);
    }
}