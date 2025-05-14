using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoDesertoScript : MonoBehaviour
{
    private string scene;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        scene = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scene == "TransicaoDeserto_China")
            {
                SceneManager.LoadScene("China1");

            }
            else if (scene == "TransicaoChinaMedieval")
            {
                SceneManager.LoadScene("Medieval1");
            }
            else if (scene == "TransicaoMedievalFazenda")
            {
                SceneManager.LoadScene("CutsceneMeioJogo");
            }
        }

    }
}
