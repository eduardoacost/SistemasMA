using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CantutaEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entro");
        // Verifica si el objeto que entró en el collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Personaje");
            // Carga la nueva escena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
