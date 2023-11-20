using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPregunta : MonoBehaviour
{

    public GameObject preguntasActivar;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            preguntasActivar.SetActive(true);
        }
    }
}
