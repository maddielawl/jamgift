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
            moveX = -1f;
        }
        if (Input.GetKey(rightKey))
        {
            moveX = 1f;
        }
        if (Input.GetKey(upKey))
        {
            moveY = 1f;
        }
        if (Input.GetKey(downKey))
        {
            moveY = -1f;
        }

        // Set the player's velocity based on the input values
        rb.velocity = new Vector2(moveX, moveY);
    }
}

