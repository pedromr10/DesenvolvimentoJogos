/*
VERSÃO 1
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

    private int vida = 50;

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

    public void DispararOnda()
    {
        if (prefabOnda != null && pontoDeSpawn != null)
        {
            GameObject onda = Instantiate(prefabOnda, pontoDeSpawn.position, Quaternion.identity);

            Vector2 direcao = transform.localScale.x > 0 ? Vector2.left : Vector2.right;

            onda.GetComponent<OndaDeAtaque>().direcao = direcao;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Algo colidiu com a Morte: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bullet")) 
        {
            Destroy(collision.gameObject); 

            vida--;
            Debug.Log("Morte atingida! Vida restante: " + vida);

            if (vida <= 0)
            {
                Morrer();
            }
        }
    }

    void Morrer()
    {
        Debug.Log("Morte derrotada!");
        Destroy(gameObject);
    }
}
*/






// VERSAO 2
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorteController : MonoBehaviour
{
    public GameObject prefabOnda;
    public Transform pontoDeSpawn;
    public Transform jogador;
    public float distanciaAtaque = 2f;
    public float tempoEntreAtaques = 2f;

    private Animator animator;
    private float tempoUltimoAtaque = 0f;

    private int vida = 50;

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

    public void DispararOnda()
    {
        if (prefabOnda != null && pontoDeSpawn != null)
        {
            GameObject onda = Instantiate(prefabOnda, pontoDeSpawn.position, Quaternion.identity);
            Vector2 direcao = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
            onda.GetComponent<OndaDeAtaque>().direcao = direcao;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Algo colidiu com a Morte: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bullet")) 
        {
            Destroy(collision.gameObject); 

            vida--;
            Debug.Log("Morte atingida! Vida restante: " + vida);

            if (vida <= 0)
            {
                Morrer();
            }
        }
    }

    void Morrer()
    {
        SceneManager.LoadScene("CutsceneFinal");
        Destroy(gameObject);
    }
}


