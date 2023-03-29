using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTriangle : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.position;
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = newPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        bool isInsideSquare = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Square"))
            {
                if (!isInsideSquare)
                {
                    transform.position = new Vector3(2.5f, 2.7f, -1);
                    isInsideSquare = true;
                }
            }
        }
            if (!isInsideSquare)
            {
            // Restablecer la posición inicial del triángulo
            transform.position = initialPosition;
            }
    }
}