using Peebo.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Peebo.Runtime.Audio;

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
        [SerializeField] public Transform rubishContainer;
        [SerializeField] public GameObject[] stains;

        [Header("Event Listeners")]
        [SerializeField] public UnityEvent onGameEnd;

        // Start is called before the first frame update
        void Start()
        {
            FindObjectOfType<AudioManager>().Play("MinigameBG");
        }

        // Update is called once per frame
        void Update()
        {
            if (rubishContainer.childCount <= 0)
            {
                // DONE!
                Debug.Log("cleaning done!");
                SceneManager.LoadScene("ComicLove");
            }
        }

        public void OnStainWiped(StainWipeEventData eventData)
        {
            Debug.Log("Wiped stain " + eventData.RemovedStain.name);
        }
    }
}
