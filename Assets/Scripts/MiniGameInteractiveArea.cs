using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInteractiveArea : MonoBehaviour
{
    public bool isStart;

    public GameObject TileMapMinigame;
    public GameObject ActualTileMap;
    public Transform SpawnMinigame;
    public Transform LastPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<BotonInteractivo>().interactMode = true;
            collision.GetComponent<BotonInteractivo>().interactableObject = this.gameObject;
            LastPosition = collision.transform;

        }
        else if (collision.tag == "Pickable")
        {
            gameObject.GetComponent<BrasilMinijuego_1>().CheckAnswer(collision.gameObject.GetComponent<BananasMovimiento>().id);
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<BotonInteractivo>().interactMode = false;
            //LastPosition = null;
            isStart = false;
        }
        
    }
}
