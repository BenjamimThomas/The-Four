using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // faz o objeto n�o ser destru�do ao mudar de cena
        }
        else
        {
            Destroy(gameObject); // se j� existir, destr�i o duplicado
        }
    }
}