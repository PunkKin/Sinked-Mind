using UnityEngine;
using UnityEditor; // Nécessaire pour quitter l'éditeur

public class Quitgame : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        // Arrête le mode Play dans l'éditeur Unity
        EditorApplication.isPlaying = false;
#else
        // Quitte l'application dans le build
        Application.Quit();
#endif
    }
}
