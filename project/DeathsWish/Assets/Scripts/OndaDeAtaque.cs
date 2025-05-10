using UnityEngine;

public class OndaDeAtaque : MonoBehaviour
{
    public float velocidade = 5f;
    public float tempoDeVida = 2f;
    public int dano = 1;
    public Vector2 direcao;

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
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

            // Exemplo: other.GetComponent<Jogador>().TomarDano(dano);

            Destroy(gameObject);
        }
    }
}
