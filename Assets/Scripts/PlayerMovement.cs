using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Physics")]
    public Rigidbody playerRB; // Player RigidBody
    public float bounceForce = 6f; // Player Bounce Force

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // When player collides with ring => Bounce player
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce"); // Play Bounce SFX
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            // The Ball Hits Safe Area

        }
        else if(materialName == "Unsafe (Instance)")
        {
            // The Ball Hits Safe Area
            GameManager.gameOver = true;

            // Play SFX
            audioManager.Play("gameOver"); // Play Game Over SFX
        }
        else if (materialName == "Last Ring (Instance)" && !GameManager.levelComplete)
        {
            // You Completed the Level
            GameManager.levelComplete = true;

            // Play SFX
            audioManager.Play("levelComplete"); // Play Level Complete SFX
        }
    }
}
