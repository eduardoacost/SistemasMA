using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivaAlgoCuandoMeToques : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objetoActivar;

    public GameObject puntoTeletransporte;

    public GameObject jugador;

    public GameObject GameManager;

    void Start()
    {
        jugador.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            objetoActivar.SetActive(true);
            GameManager.SetActive(true);
            other.gameObject.transform.position = puntoTeletransporte.transform.position;
            jugador.SetActive(false);

        }
        

    }
}
