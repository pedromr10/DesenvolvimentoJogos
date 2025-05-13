using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola_de_fogo : MonoBehaviour
{
    public Transform player;
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.TakeDamage();
            
        }
    }
}