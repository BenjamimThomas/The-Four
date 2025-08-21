using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class BotaoVoltar : MonoBehaviour
{
   
    public string Voltarmenu;

    void Start()
    {
        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(Voltarparacenamenu);
    }

    public void Voltarparacenamenu()
    {
        SceneManager.LoadScene(Voltarmenu);
    }
}