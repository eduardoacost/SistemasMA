using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivity : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject canvasPreguntas;

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

            canvasPreguntas.SetActive(true);
            tilemapActividad.SetActive(true);

            triggerActividad.SetActive(false);
        }
    }
}
