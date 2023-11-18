using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCapybara : MonoBehaviour
{
    public static GameManagerCapybara Instance;  // Singleton para acceder a la instancia de GameManager desde otros scripts

    public int totalInstances;  // Número total de instancias creadas
    public int puntos;  // Puntos actuales

    public bool seCompletoElJuego;

    public SpawneoBasura spawneoBasura;


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
        spawneoBasura = GameObject.Find("ActivacionMinijuego").GetComponent<SpawneoBasura>();

    }

    public void inicioJuego()
    {
        Instance.seCompletoElJuego = false;
        Instance.totalInstances = spawneoBasura.instances;
    }

    public bool CheckScore()
    {
        if (puntos >= totalInstances)
        {
            Instance.seCompletoElJuego = true;
            return seCompletoElJuego;
        }
        return false;
    }
}
