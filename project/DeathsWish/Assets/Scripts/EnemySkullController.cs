using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkullController : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 2f;
    private Transform alvoAtual;
    public Transform player;
    private PlayerController playerController;


    void Start()
    {
        alvoAtual = pontoB;
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvoAtual.position, velocidade * Time.deltaTime);
        if (Vector2.Distance(transform.position, alvoAtual.position) < 0.1f)
        {
            if (alvoAtual == pontoB)
            {
                alvoAtual = pontoA;
            }

            else {
                alvoAtual = pontoB;
            }
                
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
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
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
