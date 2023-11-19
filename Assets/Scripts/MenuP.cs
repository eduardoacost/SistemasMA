using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuP : MonoBehaviour
{
    public GameObject menuPausaUI;
    public GameObject configuracionUI;
    public GameObject AyudaUI;
    public GameObject TareasUI;
    public GameObject Tareas2UI;
    public GameObject MapaUI;
    public GameObject MBrazilUI;
    

    private bool juegoPausado = false;

    private void Start()
    {
        menuPausaUI.SetActive(false);
        configuracionUI.SetActive(false);
        AyudaUI.SetActive(false);
        TareasUI.SetActive(false);
        Tareas2UI.SetActive(false);

    }

    public void PausarJuego()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        menuPausaUI.SetActive(false);
        configuracionUI.SetActive(false); // Asegúrate de ocultar la interfaz de configuración si estaba abierta.
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void AbrirConfiguracion()
    {
        configuracionUI.SetActive(true);
        menuPausaUI.SetActive(false);
    }
       public void CerrarConfiguracion()
    {
        configuracionUI.SetActive(false);
        menuPausaUI.SetActive(true);
    }

    public void SalirDelJuego()
    {
        Application.Quit(); // Esto cierra la aplicación (debes estar en modo de compilación para ejecutables).
    }

    public void SalirDelMenuPausa()
    {
        menuPausaUI.SetActive(false);
    }
    public void SalirDelConfig()
    {
        configuracionUI.SetActive(false);
    }
     public void Abriraiuda()
    {
        AyudaUI.SetActive(true);
       
    }
     public void Cerraraiuda()
    {
        AyudaUI.SetActive(false);
       
    }
     public void AbrirTareas()
    {
        AyudaUI.SetActive(false);
        TareasUI.SetActive(true);
        Tareas2UI.SetActive(false);
    }
    public void CerrarTareas()
    {
        AyudaUI.SetActive(false);
        TareasUI.SetActive(false);
        Tareas2UI.SetActive(false);
    }
     public void AbrirTareas2()
    {
        TareasUI.SetActive(false);
        Tareas2UI.SetActive(true);
    }
    public void CerrarTareas2()
    {
        AyudaUI.SetActive(false);
        TareasUI.SetActive(false);
        Tareas2UI.SetActive(false);
    }

    public void Abriramapa()
    {
        MapaUI.SetActive(true);
       
    }

     public void Cerrarmapa()
    {
        MapaUI.SetActive(false);
       
    }
     
    public void AbrirMb()
    {
        MBrazilUI.SetActive(true);
       
    }

     public void CerrarMb()
    {
        MBrazilUI.SetActive(false);
       
    }
}

