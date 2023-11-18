using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BananasMovimiento : MonoBehaviour
{
    public int id;
    public bool siendoArrastrado = false;
    private Vector3 posicionInicialDelRaton;
    private Vector3 desplazamiento;
    private Vector3 posicionInicialDelObjeto;
    [SerializeField] Camera Cam;
    [SerializeField] Sprite[] Sprites;
    SpriteRenderer SR;
    Vector3 originalTransform;

    private void Start()
    {
        originalTransform = transform.position;
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        SR.sprite = Sprites[id];
        if (id != 0)
        {
            Draggable();
        }

        
        
    }

    void Draggable()
    {
        if (siendoArrastrado)
        {
            Vector3 direccionDelDesplazamiento = (Cam.ScreenToWorldPoint(Input.mousePosition) + desplazamiento) - posicionInicialDelRaton;
            transform.position = posicionInicialDelObjeto + new Vector3(direccionDelDesplazamiento.x, direccionDelDesplazamiento.y, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                siendoArrastrado = true;
                posicionInicialDelRaton = Cam.ScreenToWorldPoint(Input.mousePosition);
                posicionInicialDelObjeto = transform.position;
                desplazamiento = posicionInicialDelObjeto - posicionInicialDelRaton;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            siendoArrastrado = false;
            MoveToOrigin();
        }
    }

    public void SetNum(int BananaNum, Camera cam)
    {
        id = BananaNum;
        Cam = cam;
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }

    public void MoveToOrigin()
    {
        Debug.Log("origin");
        GetComponent<Rigidbody2D>().MovePosition(originalTransform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "Recolectable")
        {
            GameObject.Find("Tamarino").GetComponent<BrasilMinijuego_1>().AddBanana();
            Delete();
        }
    }
}
