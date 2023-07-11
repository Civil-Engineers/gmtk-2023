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
    /// When all stains are wiped clean and all trash are thrown away,
    /// switch to next cutscene using SceneManager.
    /// </summary>
    public class CleaningGameManager : MonoBehaviour
    {
        [SerializeField] public Transform rubbishContainer;

        [Header("Event Listeners")]
        [SerializeField] public UnityEvent onGameEnd;

        // Start is called before the first frame update
        void Start()
        {
            AudioManager audio = FindObjectOfType<AudioManager>();
            if(audio != null)
            {
                audio.Play("MinigameBG");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (rubbishContainer.childCount > 0) return;

            SceneManager.LoadScene("ComicLove");
        }

        public void OnStainWiped(StainWipeEventData eventData)
        {
            Debug.Log("Wiped stain " + eventData.RemovedStain.name);
        }
    }
}
