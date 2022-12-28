using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // List of points on the path
    public List<Vector2> pathPoints;

    // Rigidbody2D component attached to the enemy
    private Rigidbody2D rb;

    // Current position on the path
    private int currentPathPoint = 0;
    
    // Reference to the player GameObject
    public GameObject player;

    // Radius of the enemy's cone of vision
    public float visionRadius = 5f;

    // Angle of the enemy's cone of vision
    public float visionAngle = 90f;

    // Flag indicating if the player is within the cone of vision
    private bool playerInRange = false;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move towards the current path point
        rb.MovePosition(Vector2.MoveTowards(transform.position, pathPoints[currentPathPoint], Time.deltaTime));

        // Check if the enemy has reached the current path point
        if (Vector2.Distance(transform.position, pathPoints[currentPathPoint]) < 0.1f)
        {
            // Increment the path point index
            currentPathPoint++;

            // If the enemy has reached the last point, set the index back to the first point
            if (currentPathPoint >= pathPoints.Count)
            {
                currentPathPoint = 0;
            }
        }
        
        // Use OverlapCircle to detect colliders within the vision radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, visionRadius);

        // Check each detected collider
        foreach (Collider2D collider in colliders)
        {
            // Check if the collider is the player
            if (collider.gameObject == player)
            {
                // Calculate the angle between the enemy and the player
                float angle = Vector2.Angle(transform.position, player.transform.position);

                // Check if the angle is within the vision angle
                if (angle <= visionAngle / 2f)
                {
                    // Player is within the cone of vision, set playerInRange flag to true
                    playerInRange = true;
                }
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Set the color of the cone based on the player in range flag
        if (playerInRange)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        // Calculate the forward and up vectors for the cone based on the enemy's transform
        Vector3 forward = transform.rotation * Vector3.right;
        Vector3 up = transform.rotation * Vector3.up;

        // Draw the cone using the DrawFrustum function
        Gizmos.DrawFrustum(transform.position, visionAngle, visionRadius, 0.1f, 1f, forward, up);
    }
}

    


