using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesertoMaoDireita : MonoBehaviour
{
    public Transform player;
    private PlayerController playerController;
    private int vidaMaoDireita = 3;
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
            Debug.Log("dano");
            playerController.TakeDamage();
        }
        if (collision.CompareTag("Bullet"))
        {
            if (vidaMaoDireita <= 1)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else
            {
                vidaMaoDireita--;
            }

        }
    }
}
