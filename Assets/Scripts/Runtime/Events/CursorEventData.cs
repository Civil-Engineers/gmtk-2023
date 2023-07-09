using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Events
{
    /// <summary>
    /// Whenever cursor changes textures, this event is created
    /// </summary>
    public class CursorEventData : BaseEventData
    {
        public CursorEventData(EventSystem eventSystem) : base(eventSystem)
        {
        }

        public Texture2D[] Textures { get; set; }
    }
}
