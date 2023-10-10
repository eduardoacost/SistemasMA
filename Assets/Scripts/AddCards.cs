using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCards : MonoBehaviour
{
    [SerializeField] private Transform cardsField;

    [SerializeField] private GameObject butonPrefab;

    public int cantidadCartas;

    private void Awake()
    {
        for(int i= 0; i < cantidadCartas; i++)
        {
            GameObject cardInstance = Instantiate(butonPrefab);
            cardInstance.name = " " + i;
            cardInstance.transform.SetParent(cardsField, false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
