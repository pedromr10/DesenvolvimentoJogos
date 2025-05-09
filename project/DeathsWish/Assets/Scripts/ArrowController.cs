using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Settings")]
    public int damage = 1;
    public float lifetime = 3f;
    public bool destroyOnAnyCollision = true;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D arrowCollider;

    void Start()
    {
        Destroy(gameObject, lifetime);

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (arrowCollider == null) arrowCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            player.TakeDamage();
            Destroy(gameObject);
        }
        else if (destroyOnAnyCollision)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(Vector2 velocity)
    {
        if (rb != null)
        {
            rb.velocity = velocity;
        }
    }
}