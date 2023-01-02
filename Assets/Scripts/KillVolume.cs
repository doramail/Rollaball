using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // access the player controller
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Kill the player
                playerController.KillPlayer();
            }
        }
    }
}
