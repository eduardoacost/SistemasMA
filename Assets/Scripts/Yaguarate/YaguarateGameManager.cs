using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaguarateGameManager : MonoBehaviour
{
    public static YaguarateGameManager Instance;
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
