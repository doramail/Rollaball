using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumPad : MonoBehaviour
{
    [SerializeField] float upwardBounce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // if other collider is the "Player", the do something.
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player has entered.");
            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();


            // If we found a rigidbody, apply force.
            if (playerRigidbody != null)
            {
                // Apply a vertical velocity to the player.
                playerRigidbody.velocity = new Vector3(0, upwardBounce, 0);
            }
        }
    }
}
