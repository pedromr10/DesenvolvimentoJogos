using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public GameObject[] imagens;
    public Image fadePanel;
    public float tempoPorImagem = 5f;
    public float tempoFade = 1f;

    private void Start()
    {
        foreach (GameObject img in imagens)
            img.SetActive(false);

        imagens[0].SetActive(true);
        StartCoroutine(RodarCutscene());
    }

    IEnumerator RodarCutscene()
    {
        for (int i = 0; i < imagens.Length; i++)
        {
            imagens[i].SetActive(true);

            yield return StartCoroutine(Fade(1, 0));
            yield return new WaitForSeconds(tempoPorImagem);
            yield return StartCoroutine(Fade(0, 1));

            imagens[i].SetActive(false);
        }

        // carrega próxima cena depois da primeira cutscene
        SceneManager.LoadScene("Fazenda_1");
    }

    IEnumerator Fade(float fromAlpha, float toAlpha)
    {
        float elapsedTime = 0f;
        Color color = fadePanel.color;

        while (elapsedTime < tempoFade)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, elapsedTime / tempoFade);
            fadePanel.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        fadePanel.color = new Color(color.r, color.g, color.b, toAlpha);
    }
}
