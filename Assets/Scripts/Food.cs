using System.Collections;
using System.Collections.Generic;
using Peebo.Runtime.Pointer;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

[Serializable]
public class Food : PointAndClick
{
    public Sprite Image;
    public bool isBad;
    // public AnimationClip animation;


    // public override void OnPointerClick(PointerEventData eventData)
    // {
    //     Destroy(this.gameObject);
    //     // this.GameObject.SetActive(false);
    // }
}
