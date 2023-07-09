using Peebo.Runtime.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Peebo.Runtime.Pointer
{
    public class ChangeScene : PointAndClick
    {
        [Tooltip("Scene to change to")]
        [SerializeField] public SceneAsset scene;

        public override void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
