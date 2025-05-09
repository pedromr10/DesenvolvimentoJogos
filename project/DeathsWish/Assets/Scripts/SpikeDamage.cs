using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpikeDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float invulnerabilityTime = 1f;

    [Header("Player Reference")]
    public Transform player;
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == null) return;

        if (collision.gameObject == player.gameObject)
        {
            ApplyDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player == null) return;

        if (collision.gameObject == player.gameObject)
        {
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        playerController.TakeDamage();

    }
}