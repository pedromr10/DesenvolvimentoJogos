using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    private bool isGrounded;
    private int maxHealth = 3;
    private int currentHealth;
    private float jumpCooldown = 1f;
    private float lastJump;

    //tiro:
    public GameObject balaPrefab; 
    public Transform pontoDisparo; 
    public float velocidadeTiro = 10f;  

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        lastJump = Time.time;
    }


    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded && lastJump < Time.time - jumpCooldown)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            lastJump = Time.time;
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.P))   
        {
            Atirar();
        }
    }

    void Atirar()
    {
        GameObject bala = Instantiate(balaPrefab, pontoDisparo.position, Quaternion.identity);

        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(transform.localScale.x * velocidadeTiro, 0f); 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log($"Perdeu 1 vida ({currentHealth})");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Perdeu");
    }
}
