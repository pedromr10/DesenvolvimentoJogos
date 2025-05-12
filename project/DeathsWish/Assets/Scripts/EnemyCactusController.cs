using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCactusController : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    private int cactusLife = 2;
    private PlayerController playerController;

    // Vari�veis de tiro
    public GameObject balaPrefab;
    public Transform pontoDisparo;
    private float velocidadeTiro = 3f;
    private float intervaloTiros = 3f;
    private float distanciaDeteccao = 5f; 

    private float tempoProximoTiro = 0f;
    private AudioSource audioSource;
    public AudioClip tiroClip;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distanciaParaPlayer = Vector2.Distance(transform.position, player.position);
        animator.SetBool("atirou", false);
        if (distanciaParaPlayer <= distanciaDeteccao)
        {
            if (Time.time >= tempoProximoTiro)
            {
                Atirar();
                tempoProximoTiro = Time.time + intervaloTiros;

            }
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

            if (cactusLife < 1)
            {
                Destroy(gameObject);
            }
            else
            {
                cactusLife -= 1;
            }
        }
    }

    void Atirar()
    {
        audioSource.PlayOneShot(tiroClip);
        animator.SetBool("atirou", true);
        GameObject bala = Instantiate(balaPrefab, pontoDisparo.position, Quaternion.identity);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        Vector2 direcao = (player.position - pontoDisparo.position).normalized;
        rb.velocity = direcao * velocidadeTiro;

        

        Destroy(bala, 5f); 
    }
}
