using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosCamara : MonoBehaviour
{
    private Camera Cam;

    [SerializeField] public int[] CamSizes; // Coloca los tama�os de la c�mara aqu�

    private int currentCamPositionIndex = 0; // �ndice actual de la posici�n de la c�mara

    void Start()
    {

        Cam = GetComponent<Camera>();
        if (CamSizes.Length == 0)
        {
            Debug.LogWarning("No se han configurado posiciones de c�mara en CamPositions.");
        }
    }

    void Update()
    {
        
    }

    public void ChangeCameraPosition(int IndexPosition)
    {
        if (CamSizes.Length == 0)
        {
            return; // No hay posiciones de c�mara configuradas.
        }

        

        int targetSize = CamSizes[IndexPosition];
        Cam.orthographicSize = targetSize;
    }
}
