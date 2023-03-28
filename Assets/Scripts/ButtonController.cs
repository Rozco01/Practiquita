using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image targetImage;
    private bool isDragging = false;
    private Vector3 offset;
    private RectTransform scrollViewRectTransform;
    private RectTransform buttonRectTransform;
    private bool isParentedToImage = false;

    void Start()
    {
        // Obtener los componentes RectTransform del ScrollView y el botón
        scrollViewRectTransform = transform.parent.parent.GetComponent<RectTransform>();
        buttonRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isDragging)
        {
            // Obtener la posición del mouse en el mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Obtener la posición del botón en la vista del ScrollView
            Vector3 buttonPosition = scrollViewRectTransform.InverseTransformPoint(transform.position);

            // Verificar si el botón se encuentra en el área visible del ScrollView
            if (buttonPosition.x >= 0 && buttonPosition.x <= scrollViewRectTransform.rect.width)
            {
                // Mover el botón con el mouse
                transform.position = mousePosition + offset;
            }
        }
    }

    public void OnButtonDown()
    {
        isDragging = true;

        // Calcular la diferencia entre la posición del botón y la posición del mouse
        offset = (Vector3)transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnButtonUp()
    {
        isDragging = false;

        if (isParentedToImage)
        {
            // Si el botón ya es hijo de la imagen, simplemente lo centramos
            transform.position = targetImage.transform.position;
        }
        else if (targetImage != null && targetImage.GetComponent<BoxCollider2D>() != null &&
            targetImage.GetComponent<BoxCollider2D>().OverlapPoint(transform.position))
        {
            // Si el botón no es hijo de la imagen y está dentro del collider de la imagen, lo hacemos hijo de la imagen
            transform.SetParent(targetImage.transform);
            transform.position = targetImage.transform.position;
            isParentedToImage = true;

            // Desplazar el ScrollView para centrar la imagen
            float offset = targetImage.transform.position.x - scrollViewRectTransform.position.x;
            scrollViewRectTransform.position += new Vector3(offset, 0, 0);
        }
    }

    public void OnImageClick()
    {
        if (isParentedToImage)
        {
            // Si el botón es hijo de la imagen y se hace clic en la imagen, lo hacemos hijo del ScrollView nuevamente
            transform.SetParent(scrollViewRectTransform.transform);
            transform.position = buttonRectTransform.anchoredPosition;
            isParentedToImage = false;
        }
    }
}
