using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verCaracteristicasCapybara : MonoBehaviour
{
    [SerializeField] private GameObject caracteristicasCapybara;

    [SerializeField] private GameObject jugador;

    [SerializeField] PlayerMovement movimientoJugador;
    void Start()
    {
        
        movimientoJugador = GameObject.Find("Player").GetComponent<PlayerMovement>();
        jugador = GameObject.Find("Player");
    }

    private void Awake()
    {
        
        movimientoJugador = GameObject.Find("Player").GetComponent<PlayerMovement>();
        jugador = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == ("Player"))
        {
            caracteristicasCapybara.SetActive(true);
            

            // Verifica si el componente fue encontrado
            if (movimientoJugador != null)
            {
                // Aquí puedes acceder a las variables y métodos públicos de pm
                // Por ejemplo, para desactivar el script playerMovement:
                movimientoJugador.enabled = false;
            }
        }
    }

    public void alejarYReactivar()
    {

        Vector3 nuevaPosicion = jugador.transform.position;
        nuevaPosicion.y += 5;
        jugador.transform.position = nuevaPosicion;
        movimientoJugador.enabled = true;
        caracteristicasCapybara.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
