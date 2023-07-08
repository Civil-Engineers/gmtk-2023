using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Will listen for Pointer events for the attached GameObject.
/// GameObject must be a UI component (Image, RawImage, Text).
/// </summary>
public class PointAndClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
    IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // TODO: Make class abstract and extendable for different types of game actions

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entered " + gameObject.name);

        // Change cursor to pointer sprite
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exited " + gameObject.name);

        // Change cursor to normal sprite
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down " + gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up " + gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked " + eventData.pointerCurrentRaycast.gameObject.name);

        // Perform some game action depending on what GameObject it is
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag " + gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging " + gameObject.name);

        // Game logic related to dragging
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag " + gameObject.name);
    }
}
