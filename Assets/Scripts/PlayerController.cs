using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Input keys for movement
    public string leftKey = "a";
    public string rightKey = "d";
    public string upKey = "w";
    public string downKey = "s";

    public int speedMultiply = 0;
    
    List<GameObject> gifts = new List<GameObject>();

    // Rigidbody2D component attached to the player
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input values for movement keys
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(leftKey))
        {
            moveX = -1 * speedMultiply;
        }
        if (Input.GetKey(rightKey))
        {
            moveX = 1 * speedMultiply;
        }
        if (Input.GetKey(upKey))
        {
            moveY = 1 * speedMultiply;
        }
        if (Input.GetKey(downKey))
        {
            moveY = -1 * speedMultiply;
        }

        // Set the player's velocity based on the input values
        rb.velocity = new Vector2(moveX, moveY);
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider is a gift
        if (collider.gameObject.tag == "Gift")
        {
            // Add the gift to the list
            gifts.Add(collider.gameObject);

            // Destroy the gift game object
            Destroy(collider.gameObject);

            // Print a message indicating the gift has been collected
            Debug.Log("Gift collected! You now have " + gifts.Count + " gifts.");
        }
    }
    
}

