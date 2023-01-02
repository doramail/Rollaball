using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] Vector3 respawnPoint;

    public float speed = 10f;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;

    private int count;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        WinTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // Function body
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "count : " + count.ToString();
        if (count >= 12 ) 
        {
            WinTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        EnforceMaxSpeed();
    }

    void EnforceMaxSpeed()
    {
        // If the current player's speed is greater then what we want ... 
        if (rb.velocity.magnitude > maxSpeed)
        {
            // Cap it to maxSpeed
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    public void SetNewRespawn(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
    public void KillPlayer()
    {
        // Move player back to respawn point
        transform.position = respawnPoint;
        // Kill all velocity on player rigidbody
        rb.velocity = new Vector3(0, 0, 0);
    }
}
