using UnityEngine;

public class Archer : MonoBehaviour
{
    [Header("Shooting Settings")]
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowForce = 1f;
    public float shootCooldown = 2f;

    [Header("Detection")]
    public float detectionRange = 10f;
    public LayerMask playerLayer;

    private float cooldownTimer;
    private Transform player;
    private Camera mainCamera;
    private Renderer archerRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main;
        archerRenderer = GetComponent<Renderer>();
        cooldownTimer = shootCooldown;
    }

    void Update()
    {
        if (!IsVisibleOnCamera()) return;

        cooldownTimer -= Time.deltaTime;

        if (PlayerInRange() && cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = shootCooldown;
        }
    }

    bool IsVisibleOnCamera()
    {
        return archerRenderer.isVisible;
    }

    bool PlayerInRange()
    {
        return Vector2.Distance(transform.position, player.position) <= detectionRange;
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        Vector2 direction = (player.position - firePoint.position).normalized;
        rb.AddForce(direction * arrowForce, ForceMode2D.Impulse);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}