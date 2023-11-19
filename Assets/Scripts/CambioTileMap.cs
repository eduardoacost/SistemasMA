using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioTileMap : MonoBehaviour
{
    [SerializeField] public GameObject SiguienteTileMap;
    [SerializeField] public GameObject ActualTileMap;
    [SerializeField] public GameObject CamaraGameObject;
    [SerializeField] public int IndexCamPosition;
    [SerializeField] public GameObject SpawnPoint;
    [SerializeField] public GameObject[] ElementsToHide;
    [SerializeField] public GameObject[] ElementsToShow;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SiguienteTileMap.SetActive(true);
        ActualTileMap.SetActive(false);

        CamaraGameObject.GetComponent<MovimientosCamara>().ChangeCameraPosition(IndexCamPosition);
        Transform player = collision.GetComponent<Transform>();
        player.position = SpawnPoint.transform.position;
        if (ElementsToHide.Length != 0)
        {
            foreach (GameObject obj in ElementsToHide)
            {
                obj.SetActive(false);
            }
        } if (ElementsToShow.Length != 0)
        {
            foreach (GameObject obj in ElementsToShow)
            {
                obj.SetActive(true);
            }
        } 
     
    }
}
