using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Necesario para eventos de UI
using UnityEngine.SceneManagement;

public class IniciarJuegoPuya : MonoBehaviour
{
    public GameObject juegoPuya;

    public GameObject instruccionesJuego;

    public GameObject largestPuya;
    public GameObject caracteristicasPuya;

    public GameObject flechita;
    void Start()
    {
        juegoPuya.gameObject.SetActive(false);


    }

    void Update()
    {


        if (GameManagerPuya.Instance.seCompletoElJuego == true)
        {
            caracteristicasPuya.SetActive(true);
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            flechita.SetActive(false);

        }

    }

    IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        instruccionesJuego.SetActive(false);
        largestPuya.gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            juegoPuya.gameObject.SetActive(true);
            StartCoroutine(DeactivateAfterSeconds(3.5f));


        }
    }
}
