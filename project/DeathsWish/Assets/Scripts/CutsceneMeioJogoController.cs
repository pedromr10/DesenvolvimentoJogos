using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneMeioJogoController : MonoBehaviour
{
    public Image[] imagens;
    public Image fadePanel;
    public float tempoPorImagem = 5f;
    public float tempoFade = 1.5f;
    public string proximaCena = "NomeDaProximaCena";

    private void Start()
    {
        StartCoroutine(RodarCutscene());
    }

    IEnumerator RodarCutscene()
    {
        fadePanel.gameObject.SetActive(true);
        Color fadeColor = fadePanel.color;

        for (int i = 0; i < imagens.Length; i++)
        {
  
            for (int j = 0; j < imagens.Length; j++)
                imagens[j].gameObject.SetActive(j == i);

            
            yield return StartCoroutine(Fade(1, 0));
            yield return new WaitForSeconds(tempoPorImagem);
            
            yield return StartCoroutine(Fade(0, 1));
        }

        SceneManager.LoadScene("Fazenda_2");
    }

    IEnumerator Fade(float alphaStart, float alphaEnd)
    {
        float tempo = 0f;
        Color c = fadePanel.color;

        while (tempo < tempoFade)
        {
            float alpha = Mathf.Lerp(alphaStart, alphaEnd, tempo / tempoFade);
            fadePanel.color = new Color(c.r, c.g, c.b, alpha);
            tempo += Time.deltaTime;
            yield return null;
        }

        fadePanel.color = new Color(c.r, c.g, c.b, alphaEnd);
    }
}
