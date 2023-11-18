using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaguarateLaberinto : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Vector3 originalPosition;
    private Vector3 savedPosition;
    private float trappedTime = 0;
    private const float resetTime = 1.5f; // Tiempo antes de reiniciar la posición

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        // Para PC y dispositivos táctiles
        if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            Vector3 position = Input.touchCount > 0 ? (Vector3)Input.GetTouch(0).position : Input.mousePosition;
            StartDrag(position);
        }

        if (isDragging)
        {
            Vector3 position = Input.touchCount > 0 ? (Vector3)Input.GetTouch(0).position : Input.mousePosition;
            DragObject(position);
        }
        if (isDragging)
        {
            if (IsTrapped())
            {
                trappedTime += Time.deltaTime;
                if (trappedTime >= resetTime)
                {
                    ResetPosition();
                    trappedTime = 0;
                }
            }
            else
            {
                trappedTime = 0;
            }
        }

        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            StopDrag();
        }

        // Reiniciar la posición si está atrapado
        if (isDragging && IsTrapped())
        {
            ResetPosition();
        }
    }

    private void StartDrag(Vector3 position)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            offset = transform.position - worldPosition;
        }
    }

    private void DragObject(Vector3 position)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Vector3 targetPosition = new Vector3(worldPosition.x + offset.x, worldPosition.y + offset.y, transform.position.z);

        // Usando Rigidbody2D para mover el objeto
        rb.MovePosition(targetPosition);
    }

    private void StopDrag()
    {
        isDragging = false;
        savedPosition = gameObject.transform.position;
    }

    private bool IsTrapped()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != gameObject)
            {
                return true; // El objeto está atrapado dentro de otro collider
            }
        }
        return false;
    }

    private void ResetPosition()
    {
        transform.position = savedPosition;
        isDragging = false;
    }

    public void mandarAlInicio()
    {
        transform.position = originalPosition;
        isDragging = false;
    }
}
