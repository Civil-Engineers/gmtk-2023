using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Events
{
    /// <summary>
    /// Each stain wipe creates this event containing relevant data.
    /// </summary>
    public class StainWipeEventData : BaseEventData
    {
        public StainWipeEventData(EventSystem eventSystem) : base(eventSystem)
        {
        }

        public GameObject RemovedStain { get; set; }
    }
}
