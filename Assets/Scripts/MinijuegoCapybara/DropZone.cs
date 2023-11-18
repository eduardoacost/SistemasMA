using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string trashTag = "Basura";
    public RectTransform targetArea; // Asegúrate de asignar esto en el Inspector

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();

        if (droppedObject != null && droppedObject.CompareTag(trashTag))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(targetArea, Input.mousePosition, null))
            {
                GameManagerCapybara.Instance.puntos++;
                GameManagerCapybara.Instance.CheckScore();
                Destroy(eventData.pointerDrag); // Destruye el objeto arrastrado
            }
        }
    }
}
