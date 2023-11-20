using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class seleccionarPuyas : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] objectToShow; // Asigna el GameObject que quieres mostrar en el Inspector

    public static int index = 1;

    private void Start()
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Comprueba si el objeto clickeado tiene el tag "correcto"
        if (eventData.pointerPress.CompareTag("correcto"))
        {
            // Mostrar el objeto cuando se hace clic en un objeto con el tag "correcto"
            if (objectToShow != null)
            {
                objectToShow[index - 1].SetActive(false);

                if(index < objectToShow.Length)
                {
                    objectToShow[index].SetActive(true);
                    
                }
                
            }
            index++;

        }
        else if (gameObject.CompareTag("incorrecto"))
        {
            // Reiniciar la escena si se hace clic en cualquier lugar fuera del objeto
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Update()
    {
        if (index > objectToShow.Length)
        {
            ganoJuego();
        }
    }


    public void ganoJuego()
    {
        GameManagerPuya.Instance.ganoElJuego();
    }

    
}
