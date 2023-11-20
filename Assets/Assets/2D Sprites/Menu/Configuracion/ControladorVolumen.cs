using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControladorVolumen : MonoBehaviour
{
    public Image barraDeVolumen;
    public Sprite[] imagenesDeBarra; // Asegúrate de asignar las imágenes en el inspector
    public Button botonSubirVolumen;
    public Button botonBajarVolumen;

    private int nivelDeVolumen = 0;

    void Start()
    {
        // Asigna las funciones a los eventos de clic de los botones
        botonSubirVolumen.onClick.AddListener(SubirVolumen);
        botonBajarVolumen.onClick.AddListener(BajarVolumen);
    }

    void SubirVolumen()
    {
        if (nivelDeVolumen < imagenesDeBarra.Length - 1)
        {
            nivelDeVolumen++;
            ActualizarBarraDeVolumen();
            AjustarVolumen();
        }
    }

    void BajarVolumen()
    {
        if (nivelDeVolumen > 0)
        {
            nivelDeVolumen--;
            ActualizarBarraDeVolumen();
            AjustarVolumen();
        }
    }

    void ActualizarBarraDeVolumen()
    {
        // Asegúrate de que la barra de volumen tenga suficientes imágenes asignadas
        if (nivelDeVolumen < imagenesDeBarra.Length)
        {
            barraDeVolumen.sprite = imagenesDeBarra[nivelDeVolumen];
        }
    }

    void AjustarVolumen()
    {
        // Ajusta el volumen del sistema según el nivel de la barra
        float volumen = nivelDeVolumen / (float)(imagenesDeBarra.Length - 1);
        AudioListener.volume = volumen;
    }
}
