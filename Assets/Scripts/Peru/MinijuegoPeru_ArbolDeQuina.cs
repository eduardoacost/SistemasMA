using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinijuegoPeru_ArbolDeQuina : MonoBehaviour
{
    // Start is called before the first frame update

    public int contador;
    public Image arbol;
    public Sprite arbol1;
    public Sprite arbol2;
    public Sprite arbol3;
    public Image detector;
    public Image message;
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (contador)
        {
            case 1:
                arbol.sprite = arbol1;
                detector.rectTransform.localPosition = new Vector2(30.8f, -98.1f);
                break;
            case 2:
                arbol.sprite = arbol2;
                detector.rectTransform.localPosition = new Vector2(9.6f, -133.7f);
                break;
            case 3:
                arbol.sprite = arbol3;

                detector.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void onclick()
    {
        if(contador <= 2)
        {
            contador += 1;
        }
    }

    public void clickMessage()
    {
        message.gameObject.SetActive(false);
        detector.gameObject.SetActive(true);
    }


}
