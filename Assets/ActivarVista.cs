using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarVista : MonoBehaviour
{

    public AudioClip[] footstepSounds; // Array to hold footstep sound clips
    public float minTimeBetweenFootsteps = 0.3f; // Minimum time between footstep sounds
    public float maxTimeBetweenFootsteps = 0.6f; // Maximum time between footstep sounds

    public AudioSource audioSource; // Reference to the Audio Source component
    public Footsteps footsteps;
    private bool isTerrain = false;

    private float timeSinceLastFootstep; // Time since the last footstep sound


    private void Update()
    {
        // Check if the player is walking
        if (footsteps.isWalking && isTerrain)
        {
            // Check if enough time has passed to play the next footstep sound
            if (Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
            {
                // Play a random footstep sound from the array
                AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
                audioSource.PlayOneShot(footstepSound);

                timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
            }
        }
    }



    public void InTerrain()
    {
        isTerrain = true;
    }

    // Call this method when the player stops walking
    public void OutTerrain()
    {
        isTerrain = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            InTerrain();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OutTerrain();
        }
    }
}
