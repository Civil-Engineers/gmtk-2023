using System.Collections;
using System.Collections.Generic;
using Peebo.Runtime.Pointer;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Food
{
    public enum FoodType
    {
        Good,
        Bad
    }

    public class Food : PointAndClick
    {
        public FoodType foodType;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            Destroy(this.gameObject);
        }
    }
}
