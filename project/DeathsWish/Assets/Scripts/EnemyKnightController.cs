using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyKnightController : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float minDistance = 1.5f;
    public float damageCooldown = 1f;

    private Rigidbody2D rb;
    private float lastDamageTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastDamageTime = -damageCooldown;

        if (player == null)
        {
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

            if (playerGO != null)
            {
                player = playerGO.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > minDistance)
            {
                Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
                Vector2 newPos = rb.position + direction * speed * Time.fixedDeltaTime;
                rb.MovePosition(newPos);
            }
            else
            {
                if (Time.time - lastDamageTime >= damageCooldown)
                {
                    PlayerController playerController = player.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage();
                        lastDamageTime = Time.time;
                    }
                }
            }

            if (player.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
