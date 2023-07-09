using Peebo.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Pointer
{
    public class CustomMouseCursor : PointAndClick
    {
        [Tooltip("Sprites to use for cursor OnPointerEnter")]
        [SerializeField] public Texture2D[] pointerCursors;
        [Tooltip("Sprites to use for default cursor")]
        [SerializeField] public Texture2D[] defaultCursors;

        [Header("Event System")]
        [Tooltip("The event system to use for event handling")]
        [SerializeField] public EventSystem eventSystem;

        [Header("Event Listeners")]
        [SerializeField] public UnityEvent<CursorEventData> onCursorChange;

        public override void OnPointerExit(PointerEventData eventData)
        {
            CursorEventData cursorData = new(eventSystem)
            {
                Textures = defaultCursors
            };
            onCursorChange?.Invoke(cursorData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            CursorEventData cursorData = new(eventSystem)
            {
                Textures = pointerCursors
            };
            onCursorChange?.Invoke(cursorData);
        }
    }
}
