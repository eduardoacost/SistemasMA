using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoYaguarete : MonoBehaviour
{
    public AudioSource fuente2;
    public AudioClip clip2;
    
    void Start()
    {
        fuente2.clip = clip2;
    }

    public void Reproducir(){
        fuente2.Play();
    }

}  
