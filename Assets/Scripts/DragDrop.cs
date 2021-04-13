using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IEndDragHandler, IDragHandler
{
    Canvas canvas;
    RectTransform rectTransform;
    GameObject parent;
    Vector3 originalPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        // note the parent and position of the card
        // this way I can return it when done.
        parent = gameObject.transform.parent.gameObject;
        originalPosition = gameObject.transform.position;

        gameObject.transform.SetParent(canvas.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = originalPosition;
    }

    // my methods
}
