using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float smoothing;
    private Vector2 smoothDirection;
    private Vector2 origin;
    private Vector2 direction;
    private bool touched;
    private int pointerID;

    private void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //set start point
        if (!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
            origin = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //compare difference
        if (eventData.pointerId == pointerID)
        {
            Vector2 currentPosition = eventData.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
         //   Debug.Log(direction);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //reset everything
        if (eventData.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }

    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
