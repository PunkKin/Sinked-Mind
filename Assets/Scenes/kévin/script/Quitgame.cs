using UnityEngine;
using UnityEditor; // N�cessaire pour quitter l'�diteur

public class Quitgame : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        // Arr�te le mode Play dans l'�diteur Unity
        EditorApplication.isPlaying = false;
#else
        // Quitte l'application dans le build
        Application.Quit();
#endif
    }
}
