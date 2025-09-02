using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipDialogo : MonoBehaviour
{

    public string pulardialogo;

    void Start()
    {

        Button botao = GetComponent<Button>();
        botao.onClick.AddListener(skipDialogo);
    }

    public void skipDialogo()
    {
        SceneManager.LoadScene(pulardialogo);
    }
}