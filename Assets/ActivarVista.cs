using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarVista : MonoBehaviour
{
    public GameObject objetoParaActivar;
    public AudioClip soundSteps;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objetoParaActivar.SetActive(true);
            other.GetComponent<Footsteps>().PlayStepSound(soundSteps);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objetoParaActivar.SetActive(false);
            other.GetComponent<Footsteps>().StopStepSound();
        }
    }
}
