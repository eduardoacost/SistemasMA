using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientosCamara : MonoBehaviour
{
    public Camera Cam;
    public Vector3[] CamPositions; // Coloca las posiciones de la cámara aquí

    public int currentCamPositionIndex = 0; // Índice actual de la posición de la cámara

    void Start()
    {
        Cam = GetComponent<Camera>();
        if (CamPositions.Length == 0)
        {
            Debug.LogWarning("No se han configurado posiciones de cámara en CamPositions.");
        }
    }

    void Update()
    {
        // Aquí puedes agregar lógica para mover la cámara, por ejemplo, en respuesta a la entrada del jugador.
        // Por ejemplo, puedes usar Input.GetKey o algún otro método para cambiar la posición de la cámara.
        if (Input.GetKeyDown(KeyCode.Space)) // Ejemplo: cambia la posición de la cámara cuando se presiona la barra espaciadora.
        {

            ChangeCameraPosition(currentCamPositionIndex);
            // Avanzar al siguiente índice de posición de la cámara (cíclicamente).
            currentCamPositionIndex = (currentCamPositionIndex + 1) % CamPositions.Length;
        }
    }

    public void ChangeCameraPosition(int IndexPosition)
    {
        if (CamPositions.Length == 0)
        {
            return; // No hay posiciones de cámara configuradas.
        }

        

        Vector3 targetPosition = CamPositions[IndexPosition];
        transform.position = targetPosition;
    }
}
