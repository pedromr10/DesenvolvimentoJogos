using UnityEngine;

public class EnemyKnightController : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 2f;
    private Transform alvoAtual;
    public Transform player;
    private PlayerController playerController;
    private int enemyLifes = 5;


    void Start()
    {
        alvoAtual = pontoA;
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvoAtual.position, velocidade * Time.deltaTime);
        if (Vector2.Distance(transform.position, alvoAtual.position) < 0.1f)
        {
            if (alvoAtual == pontoA)
            {
                alvoAtual = pontoB;
            }

            else
            {
                alvoAtual = pontoA;
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
            playerController.TakeDamage();
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            if (enemyLifes > 1)
            {
                enemyLifes -= 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
