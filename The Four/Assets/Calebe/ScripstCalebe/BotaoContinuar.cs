using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotaoContinuar : MonoBehaviour
{

    public string DialogoContinuacao;

    void Start()
    {

        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(ContinuarDialogo);
    }

    public void ContinuarDialogo()
    {
        SceneManager.LoadScene(DialogoContinuacao);
    }
}
