using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    public void ExitButtonFunction() {
        //sai do jogo, depois de buildado:
        Application.Quit();
        //sai do jogo se estiver no unity editor:
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
