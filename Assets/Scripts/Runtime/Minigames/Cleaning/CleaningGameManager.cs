using Peebo.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Peebo.Runtime.Minigames.Cleaning
{
    /// <summary>
    /// Manages game state for cleaning minigame on scene load.
    /// 
    /// It should keep track of all gameObjects that have the StainWipeHandler script.
    /// When all stains are wiped clean, switch scenes using a Scene Manager.
    /// </summary>
    public class CleaningGameManager : MonoBehaviour
    {
        [Header("Event Listeners")]
        [SerializeField] public UnityEvent onGameEnd;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnStainWiped(StainWipeEventData eventData)
        {
            Debug.Log("Wiped stain " + eventData.RemovedStain.name);
        }
    }
}
