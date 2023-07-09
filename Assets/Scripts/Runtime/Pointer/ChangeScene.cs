using Peebo.Runtime.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Peebo.Runtime.Audio;
namespace Peebo.Runtime.Pointer
{
    public class ChangeScene : PointAndClick
    {
        [Tooltip("Scene to change to")]
        [SerializeField] public string scenePath;
        void Start()
        {
            FindObjectOfType<AudioManager>().Play("AltBG");
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            FindObjectOfType<AudioManager>().Play("FridgeRustle");
            SceneManager.LoadScene(scenePath);
        }
    }
}
