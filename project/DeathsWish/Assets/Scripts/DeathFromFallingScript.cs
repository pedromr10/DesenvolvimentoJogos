using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFromFallingScript : MonoBehaviour
{
    // Update is called once per frame
    public Transform player;
    private PlayerController playerController;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.Die();
        }
    }
}
