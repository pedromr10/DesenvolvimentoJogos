using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmPortal1 : MonoBehaviour
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
            SceneManager.LoadScene("Deserto_1");
        }
    }
}
