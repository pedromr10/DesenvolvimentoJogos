using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesertoDireitaHit : MonoBehaviour
{
    public Transform player;
    public Transform maoDireita;
    private PlayerController playerController;

    public float descerDistancia = 2f;
    private float velocidade = 6f; 

    private Vector3 maoDireitaPosInicial;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        maoDireitaPosInicial = maoDireita.position; 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            Debug.Log("MAO DIREITA");

            
            StartCoroutine(MoverMaoParaBaixo());
        }
    }

    private IEnumerator MoverMaoParaBaixo()
    {
        Vector3 destino = maoDireitaPosInicial - new Vector3(0, descerDistancia, 0); 

        
        while (maoDireita.position.y > destino.y)
        {
            maoDireita.position = Vector3.MoveTowards(maoDireita.position, destino, velocidade * Time.deltaTime);
            yield return null;
        }

        maoDireita.position = destino; 

       
        yield return new WaitForSeconds(2f);

     
        while (maoDireita.position.y < maoDireitaPosInicial.y)
        {
            maoDireita.position = Vector3.MoveTowards(maoDireita.position, maoDireitaPosInicial, velocidade * Time.deltaTime);
            yield return null;
        }

        maoDireita.position = maoDireitaPosInicial; 
    }
}
