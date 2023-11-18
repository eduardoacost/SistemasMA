using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfoGuazu : MonoBehaviour
{
    public GameObject canvasInfo;
    public GameObject panelInfo;
    public GameObject panelOsorio;
    public GameObject guazu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasInfo.SetActive(true);
        }
    }

    public void ApagarInfo()
    {
        panelInfo.SetActive(false);
        panelOsorio.SetActive(true);

        Destroy(guazu.GetComponent<BoxCollider2D>());
    }

    public void ApagarOsorio()
    {
        canvasInfo.SetActive(false);
    }
}
