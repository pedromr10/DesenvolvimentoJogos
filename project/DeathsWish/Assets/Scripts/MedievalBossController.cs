using UnityEngine;

public class MedievalBossController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform player;

    private Rigidbody2D rb;
    private int enemyLifes = 50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        float yDistance = Mathf.Abs(player.position.y - transform.position.y);
        if (yDistance > 3)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }


        float direction = player.position.x - transform.position.x;

        rb.velocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.velocity.y);

        if (direction != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -Mathf.Abs(localScale.x) * Mathf.Sign(direction);
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.TakeDamage();
            }
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
