using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Find the playerController script
            PlayerController playerControler = other.gameObject.GetComponent<PlayerController>();
            if (playerControler != null)
            {
                // Get this checkpoint's position
                Vector3 newSpawnPoint = transform.position;
                // Send the checkpoint position to the player script
                playerControler.SetNewRespawn(newSpawnPoint);
            }
        }
    }
}
