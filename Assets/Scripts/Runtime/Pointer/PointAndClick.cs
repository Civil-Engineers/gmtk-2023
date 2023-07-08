using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Pointer
{
    /// <summary>
    /// Will listen for Pointer events for the attached GameObject.
    /// GameObject must be a UI component (Image, RawImage, Text).
    /// </summary>
    public abstract class PointAndClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
        IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Entered " + gameObject.name);

            // Change cursor to pointer sprite
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Exited " + gameObject.name);

            // Change cursor to normal sprite
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Down " + gameObject.name);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Up " + gameObject.name);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked " + eventData.pointerCurrentRaycast.gameObject.name);

            // Perform some game action depending on what GameObject it is
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin drag " + gameObject.name);
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging " + gameObject.name);

            // Game logic related to dragging
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("End drag " + gameObject.name);
        }
    }
}
