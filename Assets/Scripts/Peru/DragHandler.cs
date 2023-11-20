using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    public GameObject targetObject; // Objeto al que quieres arrastrar el botón.
    public MinijuegoPeru_ArbolDeQuina scriptCanvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta; // Mueve el botón con el movimiento del ratón.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Comprobar si el botón está sobre el objeto objetivo.
        if (RectTransformUtility.RectangleContainsScreenPoint(targetObject.GetComponent<RectTransform>(), Input.mousePosition))
        {
            // Llamar a la función que deseas ejecutar.
            ExecuteAction();
        }
        transform.position = startPosition; // Devuelve el botón a su posición inicial.
    }

    private void ExecuteAction()
    {
        // Aquí pones el código de la acción que quieres que se ejecute.
        scriptCanvas.contador += 1;
        Debug.Log("Acción ejecutada!");
    }
}
