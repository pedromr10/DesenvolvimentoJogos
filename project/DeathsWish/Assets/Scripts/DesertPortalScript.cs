using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertPortalScript : MonoBehaviour
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
            if (cenaAtual.name == "Deserto_1")
            {
                SceneManager.LoadScene("Deserto_2");
            }
            else if (cenaAtual.name == "Deserto_2")
            {
                SceneManager.LoadScene("Deserto_3");
            }
            else if (cenaAtual.name == "Deserto_3")
            {
                SceneManager.LoadScene("Deserto_Boss");
            }
        }
    }



}
