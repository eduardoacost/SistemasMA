using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class logicaBasuraJuegoCapybara : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image targetImage; // Asigna esto en el Inspector
    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.position;
        targetImage = GameObject.Find("CestoBasura").GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Acciones cuando comienza el arrastre
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mover el objeto de UI
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Verifica si el objeto se ha soltado dentro del área del targetImage
        if (targetImage != null && RectTransformUtility.RectangleContainsScreenPoint(targetImage.rectTransform, Input.mousePosition, null))
        {
            GameManagerCapybara.Instance.puntos++;
            GameManagerCapybara.Instance.CheckScore();
            Destroy(gameObject); // Destruye el objeto actual
        }
        else
        {
            // Si no está dentro del área, regresa a la posición original
            transform.position = originalPosition;
        }
    }
}
