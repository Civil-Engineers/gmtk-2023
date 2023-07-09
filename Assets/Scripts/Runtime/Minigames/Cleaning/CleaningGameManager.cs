using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public Transform rubishContainer;
        [SerializeField] public GameObject[] stains;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (rubishContainer.childCount <= 0)
            {
                // DONE!
            }
        }
    }
}
