using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneFinalController : MonoBehaviour
{
    public Image fadePanel;
    public float tempoFade = 2f;
    public float tempoNaTela = 8f;

    void Start()
    {
        StartCoroutine(FinalizarJogo());
    }

    IEnumerator FinalizarJogo()
    {
        // Fade In
        yield return StartCoroutine(Fade(1, 0));
        yield return new WaitForSeconds(tempoNaTela);
        
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float t = 0f;
        Color c = fadePanel.color;

        while (t < tempoFade)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t / tempoFade);
            fadePanel.color = new Color(c.r, c.g, c.b, alpha);
            t += Time.deltaTime;
            yield return null;
        }

        fadePanel.color = new Color(c.r, c.g, c.b, endAlpha);
    }
}
