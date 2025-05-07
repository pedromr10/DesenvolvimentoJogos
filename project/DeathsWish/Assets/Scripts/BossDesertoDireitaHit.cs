using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesertoDireitaHit : MonoBehaviour
{
    public Transform player;
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("MAO DIREITA");
        }
    }

}
