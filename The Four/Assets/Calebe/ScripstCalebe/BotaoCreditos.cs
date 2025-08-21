using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class BotaoCreditos : MonoBehaviour
{

    public string Creditos;

    void Start()
    {

        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(IrParaCenaCreditos);
    }

    public void IrParaCenaCreditos()
    {
        SceneManager.LoadScene(Creditos);
    }
}