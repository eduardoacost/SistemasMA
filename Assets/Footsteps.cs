using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;



    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            footstepsSound.enabled = true;

        }
        else
        {
            footstepsSound.enabled = false;

        }
    }

    public void PlayStepSound(AudioClip clip)
    {

        footstepsSound.PlayOneShot(clip);
    }

    public void StopStepSound()
    {
        footstepsSound.Stop();
    }



}
