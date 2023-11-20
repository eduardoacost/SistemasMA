using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPuya : MonoBehaviour
{
    public static GameManagerPuya Instance;
    public bool seCompletoElJuego;

    private void Awake()
    {
        // Configuración del singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void ganoElJuego()
    {
        Instance.seCompletoElJuego = true;
    }

}
