using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicioController : MonoBehaviour
{
    public GameObject canvasInicio;
    public GameObject canvasJugador;
    public GameObject canvasHistoria;

    public GameObject botonHombre;
    public Button hombreBTransform;

    public GameObject botonMujer;
    public Button mujerBTransform;

    public GameObject botonYes;
    public GameObject botonNo;

    public GameObject panelHistoria1;
    public GameObject panelHistoria2;
    public GameObject panelHistoria3;

    public void BotonInicio(){ 
        canvasInicio.SetActive(false);
        canvasJugador.SetActive(true);
    }

    public void SeleccionHombre(){
        botonMujer.SetActive(false);
        RectTransform botonTransform = hombreBTransform.GetComponent<RectTransform>();
        botonTransform.anchoredPosition = new Vector3(0,0,0);
        botonYes.SetActive(true);
        botonNo.SetActive(true);
    }

    public void SeleccionMujer(){
        botonHombre.SetActive(false);
        RectTransform botonTransform = mujerBTransform.GetComponent<RectTransform>();
        botonTransform.anchoredPosition = new Vector3(0,0,0);
        botonYes.SetActive(true);
        botonNo.SetActive(true);
    }

    public void BotonNo(){
        botonYes.SetActive(false);
        botonNo.SetActive(false);
        
        botonHombre.SetActive(true);
        botonMujer.SetActive(true);

        RectTransform hombreTransform = hombreBTransform.GetComponent<RectTransform>();
        RectTransform mujerTransform = mujerBTransform.GetComponent<RectTransform>();

        hombreTransform.anchoredPosition = new Vector3(-78,-14,0);
        mujerTransform.anchoredPosition = new Vector3(74,-14,0);
    }

    public void BotonYes()
    {
        canvasJugador.SetActive(false);
        canvasHistoria.SetActive(true);
    }

    public void BotonSiguinete1()
    {
        panelHistoria1.SetActive(false);
        panelHistoria2.SetActive(true);
    }

    public void BotonSiguinete2()
    {
        panelHistoria2.SetActive(false);
        panelHistoria3.SetActive(true);
    }
}
