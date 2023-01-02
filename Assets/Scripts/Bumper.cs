using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class Bumper : MonoBehaviour
{
    [SerializeField] float bounceAmount = 300f;
    [SerializeField] ParticleSystem feedbackParticle;
    [SerializeField] AudioSource feedbackAudio;

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
                // Debug.Log("Found player's Rigidbody");
                // Get the players's velocity and invert it.
                Vector3 bounceDirection = -playerRigidbody.velocity;
                // Apply this force.
                playerRigidbody.AddForce(bounceDirection * bounceAmount);
                // Visual feedback
                feedbackParticle.Play();
                // Audio feedback
                feedbackAudio.Play();
            }
        }
    }
}
