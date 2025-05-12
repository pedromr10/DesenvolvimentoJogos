using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesertoEsquerdaHit : MonoBehaviour
{
    public Transform player;
    public Transform maoEsquerda; 
    private PlayerController playerController;

    public float descerDistancia = 2f; 
    private float velocidade = 6f; 
    private Vector3 maoEsquerdaPosInicial;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        maoEsquerdaPosInicial = maoEsquerda.position; 
    }

    void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        
            Debug.Log("MAO ESQUERDA");

            
            StartCoroutine(MoverMaoParaBaixo());
        }
    }

    private IEnumerator MoverMaoParaBaixo()
    {
        Vector3 destino = maoEsquerdaPosInicial - new Vector3(0, descerDistancia, 0); 

       
        while (maoEsquerda.position.y > destino.y)
        {
            maoEsquerda.position = Vector3.MoveTowards(maoEsquerda.position, destino, velocidade * Time.deltaTime);
            yield return null;
        }

        maoEsquerda.position = destino; 

      
        yield return new WaitForSeconds(2f);

        
        while (maoEsquerda.position.y < maoEsquerdaPosInicial.y)
        {
            maoEsquerda.position = Vector3.MoveTowards(maoEsquerda.position, maoEsquerdaPosInicial, velocidade * Time.deltaTime);
            yield return null;
        }

        maoEsquerda.position = maoEsquerdaPosInicial; 
    }
}
