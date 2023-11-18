using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonInteractivo : MonoBehaviour
{
    public bool interactMode = false;
    public GameObject interactableObject;
    [HideInInspector]
    public bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactMode && Input.GetKeyDown(KeyCode.E))
        {
            if (interactMode)
            {
                isPress = true;
                GameObject.Find("Tamarino").GetComponent<BrasilMinijuego_1>().CheckMinigame();
                //Debug.Log(GameObject.Find("Tamarino").GetComponent<BrasilMinijuego_1>().MinigameState);
            }
        }else
        {
            isPress = false;
        }
    }

    
}
