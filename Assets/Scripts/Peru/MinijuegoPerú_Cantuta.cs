using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinijuegoPerú_Cantuta : MonoBehaviour
{
    // Start is called before the first frame update

    public Image regaderaImage; // Arrastra tu imagen "regadera" aquí en el Inspector
    private bool isRotating = false;
    public float contador;
    public Slider progreso;
    public Image planta;
    public Sprite plantaLv1;
    public Sprite plantaLv2;
    public Image flor;


    void Start()
    {
        contador = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnButtonClick()
    {
        
        if (!isRotating)
        {
            // Hacer visible la imagen
            regaderaImage.gameObject.SetActive(true);
            if (contador != 9)
            {

                contador = contador + 1;
            }


            if (contador == 2)
            {
                planta.gameObject.SetActive(true);
                planta.sprite = plantaLv1;
            }

            if (contador == 5)
            {
                planta.transform.position = planta.transform.position + new Vector3(0, 25, 0);
                RectTransform rectTransform = planta.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 150f);

                planta.sprite = plantaLv2;
            }

            if (contador == 9)
            {
                flor.gameObject.SetActive(true);
            }

            progreso.value = contador;
            // Comenzar la rotación
            StartCoroutine(RotateAndHideImage());
        }
    }

    private IEnumerator RotateAndHideImage()
    {
        isRotating = true;

        // Datos de rotación
        float duration = 1.0f; // Duración en segundos
        float rotationAmount = 30.0f; // Grados a rotar
        float elapsed = 0.0f;
        Quaternion startRotation = regaderaImage.transform.rotation;
        Quaternion midRotation = startRotation * Quaternion.Euler(0, 0, rotationAmount);

        // Rotar hacia los 30°
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsed / duration);
            regaderaImage.transform.rotation = Quaternion.Lerp(startRotation, midRotation, normalizedTime);
            yield return null;
        }

        // Resetear el tiempo y rotar de regreso a la posición original
        elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsed / duration);
            regaderaImage.transform.rotation = Quaternion.Lerp(midRotation, startRotation, normalizedTime);
            yield return null;
        }

        // Asegurarse de que la rotación final sea exactamente la posición original
        regaderaImage.transform.rotation = startRotation;

        // Hacer la imagen invisible nuevamente
        regaderaImage.gameObject.SetActive(false);

        isRotating = false;
    }
}
