using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovimientoCamaraTest
{
    [UnityTest]
    public IEnumerator ChangeCameraPosition_ShouldChangeCameraPosition()
    {
        GameObject cameraObject = new GameObject("Camera");
        MovimientosCamara movimientosCamara = cameraObject.AddComponent<MovimientosCamara>();
        movimientosCamara.CamPositions = new Vector3[] { new Vector3(1, 2, 3), new Vector3(4, 5, 6) }; // Configura posiciones de cámara para la prueba.

        // Espera un frame para que Unity tenga tiempo de procesar el Start() y configurar todo
        yield return null;

        // Al principio, la posición de la cámara debería ser la primera posición del arreglo
        Vector3 initialPosition = cameraObject.transform.position;
        Assert.AreEqual(new Vector3(0, 0, 0), initialPosition);

        // Llama a la función para cambiar la posición de la cámara
        movimientosCamara.ChangeCameraPosition(1);

        // Espera un frame para que Unity actualice la posición de la cámara
        yield return null;

        // Ahora la posición de la cámara debería ser la segunda posición del arreglo
        Vector3 newPosition = cameraObject.transform.position;
        Assert.AreEqual(new Vector3(4, 5, 6), newPosition);
    }
}
