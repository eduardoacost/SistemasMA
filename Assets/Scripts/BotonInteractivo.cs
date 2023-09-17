using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonInteractivo : MonoBehaviour
{
    public bool interactMode = false;
    public GameObject interactableObject;
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        interactMode = true;
        // Mostrar un mensaje o realizar una acción visual para indicar la posibilidad de interactuar.
    }
}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
