using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestionScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    public bool draggable;
    Vector3 startPosition;
    Transform startParent;

    // When the drag begins
    public void OnBeginDrag(PointerEventData data)
    {
        if (draggable)
        {
            itemBeingDragged = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    // while dragging
    public void OnDrag(PointerEventData eventData)
    {
        if(draggable)
        transform.position = Input.mousePosition;
    }

    // when the drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggable)
        {
            itemBeingDragged = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (transform.parent == startParent)
            {
                transform.position = startPosition;
            }
        }
    }


}
