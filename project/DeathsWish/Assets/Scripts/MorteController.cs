using UnityEngine;

public class MorteController : MonoBehaviour
{
    public GameObject prefabOnda;
    public Transform pontoDeSpawn;
    public Transform jogador;
    public float distanciaAtaque = 2f;
    public float tempoEntreAtaques = 2f;

    private Animator animator;
    private float tempoUltimoAtaque = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jogador == null)
            return;

        float distancia = Vector2.Distance(transform.position, jogador.position);

        if (distancia <= distanciaAtaque && Time.time >= tempoUltimoAtaque + tempoEntreAtaques)
        {
            Atacar();
            tempoUltimoAtaque = Time.time;
        }
    }

    void Atacar()
    {
        animator.SetTrigger("Atacar");
    }

    // Esta função será chamada no evento da animação
    public void DispararOnda()
    {
        if (prefabOnda != null && pontoDeSpawn != null)
        {
            GameObject onda = Instantiate(prefabOnda, pontoDeSpawn.position, Quaternion.identity);

            // A onda deve seguir a direção para frente (ou para o player)
            Vector2 direcao = transform.localScale.x > 0 ? Vector2.left : Vector2.right;            

            onda.GetComponent<OndaDeAtaque>().direcao = direcao;
        }
    }
}
