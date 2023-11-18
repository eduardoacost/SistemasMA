using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosCamara : MonoBehaviour
{
    private Camera Cam;

    [SerializeField] public int[] CamSizes; // Coloca los tamaños de la cámara aquí

    private int currentCamPositionIndex = 0; // Índice actual de la posición de la cámara

    void Start()
    {

        Cam = GetComponent<Camera>();
        if (CamSizes.Length == 0)
        {
            Debug.LogWarning("No se han configurado posiciones de cámara en CamPositions.");
        }
    }

    void Update()
    {
        
    }

    public void ChangeCameraPosition(int IndexPosition)
    {
        if (CamSizes.Length == 0)
        {
            return; // No hay posiciones de cámara configuradas.
        }

        

        int targetSize = CamSizes[IndexPosition];
        Cam.orthographicSize = targetSize;
    }
}
