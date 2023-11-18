using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivity : MonoBehaviour
{
    [Header("Canvas/UI")]
    public GameObject canvasPreguntas;
    public GameObject canvasInfo;
    public GameObject panelAntes;
    public GameObject panelDespues;
    public GameObject panelFinal;

    [Header("Tilemaps")]
    public GameObject tilemapMapa;
    public GameObject tilemapActividad;

    [Header("GameObjects")]
    public GameObject triggerActividad;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tilemapMapa.SetActive(false);
            player.SetActive(false);

            canvasInfo.SetActive(true);
            tilemapActividad.SetActive(true);

            triggerActividad.SetActive(false);
        }
    }

    public void ActivarActividad()
    {
        canvasPreguntas.SetActive(true);
        panelAntes.SetActive(false);
    }

    public void ActivarInfo()
    {
        panelDespues.SetActive(false);
        panelFinal.SetActive(true);
    }

    public void ApagarCanvas()
    {
        player.SetActive(true);

        canvasInfo.SetActive(false);

        tilemapMapa.SetActive(true);
        tilemapActividad.SetActive(false);
    }
}
