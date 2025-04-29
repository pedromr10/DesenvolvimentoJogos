using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifePotionScript : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //so cura o player se ele tiver menos que 3 de vida;
            if (playerController.currentHealth < 3) {
                playerController.Heal();
                Debug.Log("cura");
            }
            Destroy(gameObject);
        }
    }
}
