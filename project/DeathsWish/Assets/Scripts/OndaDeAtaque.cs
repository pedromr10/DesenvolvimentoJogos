/*
using UnityEngine;

public class OndaDeAtaque : MonoBehaviour
{
    public float velocidade = 5f;
    public float tempoDeVida = 2f;
    public int dano = 1;
    public Vector2 direcao;
    public Transform player;
    private PlayerController playerController;

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Translate(direcao.normalized * velocidade * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqui você chama a função de tomar dano no jogador
            Debug.Log("Jogador atingido!");

            playerController.TakeDamage();

            // Exemplo: other.GetComponent<Jogador>().TomarDano(dano);

            Destroy(gameObject);
        }
    }
}
*/

using UnityEngine;

public class OndaDeAtaque : MonoBehaviour
{
    public Vector2 direcao;
    public float velocidade = 5f;
    public int dano = 10; // Valor do dano que será aplicado

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Tenta acessar o script do jogador e aplicar dano
            var player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage();
            }

            Destroy(gameObject); // Destroi a onda após o impacto
        }
    }
}
