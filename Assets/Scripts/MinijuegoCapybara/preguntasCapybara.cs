using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preguntasCapybara : MonoBehaviour
{
    public GameObject preguntas1;
    public GameObject preguntas2;
    public GameObject preguntas3;
    public GameObject preguntas4;
    public GameObject[] preguntas;

    public GameObject jugador;

    int controladorPreguntas = 0;

    void Awake()
    {
        preguntas = new GameObject[] { preguntas1, preguntas2, preguntas3, preguntas4 };
    }

    void Start()
    {
        controladorPreguntas = 0;
        jugador = GameObject.FindWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespuestaUsuario(int respuesta)
    {
        if (respuesta == 0)
        {
            ocultarTodasPreguntas();
            moverJugador();
            controladorPreguntas = 0;

        }
        else if (respuesta == 1)
        {
            mostrarSiguientePregunta(controladorPreguntas);
            controladorPreguntas++;;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            preguntas1.gameObject.SetActive(true);
            
        }
    }

    void moverJugador()
    {
        jugador.transform.position = new Vector2(jugador.transform.position.x - 5, jugador.transform.position.y);
    }

    void mostrarSiguientePregunta(int controladorPreguntas)
    {
      
        if (controladorPreguntas == 4)
        {
            gameObject.SetActive(false);
            ocultarTodasPreguntas();
            return;
        }

        if (controladorPreguntas != 0)
        {
            preguntas[controladorPreguntas - 1].gameObject.SetActive(false);
        }
        preguntas[controladorPreguntas].gameObject.SetActive(true);

        
    }

    void ocultarTodasPreguntas()
    {
        preguntas1.gameObject.SetActive(false);
        preguntas2.gameObject.SetActive(false);
        preguntas3.gameObject.SetActive(false);
        preguntas4.gameObject.SetActive(false);
    }
}
