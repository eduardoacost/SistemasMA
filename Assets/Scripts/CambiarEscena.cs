using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    public int escenas;
    public void Cambiar(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
            SceneManager.LoadScene(escenas);
        
    }
}
