using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB; // Player RigidBody
    public float bounceForce = 6f; // Player Bounce Force

    // When player collides with ring => Bounce player
    private void OnCollisionEnter(Collision collision)
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            // The Ball Hits Safe Area

            // Play SFX

        }
        else if(materialName == "Unsafe (Instance)")
        {
            // The Ball Hits Safe Area
            GameManager.gameOver = true;

            // Play SFX

        }
        else if (materialName == "Last Ring (Instance)")
        {
            // You Completed the Level
            GameManager.levelComplete = true;

            // Play SFX
        }
    }
}
