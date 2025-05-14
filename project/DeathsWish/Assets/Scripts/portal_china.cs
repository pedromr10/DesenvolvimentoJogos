using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portal_china : MonoBehaviour
{
    
    private Scene cenaAtual;
    public static bool ChinaSecreto = false;
    bananaScript bananaScript;
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
            if (cenaAtual.name == "China1")
            {
                SceneManager.LoadScene("China2");
            }
            else if (cenaAtual.name == "China2")
            {
                SceneManager.LoadScene("China3");
            }
            else if (cenaAtual.name == "China3")
            {
                if (ChinaSecreto){
                    Debug.Log("entrou");
                    SceneManager.LoadScene("ChinaBoss2");    
                }
                else{
                    SceneManager.LoadScene("ChinaBoss");
                }
                
            }
        }
    }



}
