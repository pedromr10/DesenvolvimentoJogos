using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MedievalPortal : MonoBehaviour
{
    private Scene cenaAtual;
    void Start()
    {
        cenaAtual = SceneManager.GetActiveScene();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (cenaAtual.name == "Medieval1")
            {
                SceneManager.LoadScene("Medieval2");
            }
            else if (cenaAtual.name == "Medieval2")
            {
                SceneManager.LoadScene("Medieval3");
            }
            else if (cenaAtual.name == "Medieval3")
            {
                SceneManager.LoadScene("MedievalBoss");
            }
        }
    }



}
