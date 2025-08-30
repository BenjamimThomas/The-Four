using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // faz o objeto não ser destruído ao mudar de cena
        }
        else
        {
            Destroy(gameObject); // se já existir, destrói o duplicado
        }
    }
}