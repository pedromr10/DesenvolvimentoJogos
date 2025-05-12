using UnityEngine;
using UnityEngine.SceneManagement;
public class BossDesertoHeadScript : MonoBehaviour
{ 
    private float followSpeed = 0.5f;  
    private int vidaCabecote= 5;
    public Transform player;
    private PlayerController playerController;

    void Start(){
        playerController = player.GetComponent<PlayerController>();

    }

    void Update()
    {
     
        Vector3 newPosition = transform.position;


        newPosition.x = Mathf.Lerp(transform.position.x, player.position.x, followSpeed * Time.deltaTime);

        transform.position = newPosition;
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
            if (vidaCabecote <= 1)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                SceneManager.LoadScene("TransicaoDeserto_China");
            }
            else
            {
                vidaCabecote--;
            }

        }
    }
}
