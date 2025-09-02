using UnityEngine;

public class BotaoSair : MonoBehaviour
{
    public void FecharJogo()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}