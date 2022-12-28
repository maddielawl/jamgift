using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDefuser : MonoBehaviour
{
    // The bomb game object
    public GameObject bomb;

    // The defuse key
    public KeyCode defuseKey = KeyCode.Space;

    // The defuse time in seconds
    public float defuseTime = 3f;

    // The defuse timer
    private float defuseTimer = 0f;

    public bool canDefuse = false;

    void Update()
    {
        // Check if the defuse key is being pressed
        if (Input.GetKey(defuseKey))
        {
            // Increment the defuse timer
            defuseTimer += Time.deltaTime;

            // Check if the defuse timer has reached the defuse time
            if (defuseTimer >= defuseTime)
            {
                // Defuse the bomb
                DefuseBomb();
            }
        }
        else
        {
            // Reset the defuse timer if the defuse key is not being pressed
            defuseTimer = 0f;
        }
    }

    void DefuseBomb()
    {
        // Deactivate the bomb game object
        bomb.SetActive(false);

        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canDefuse = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {

        canDefuse = false;

    }

}