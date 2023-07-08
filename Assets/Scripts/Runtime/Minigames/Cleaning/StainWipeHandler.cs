using Peebo.Runtime.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Peebo.Runtime.Minigames.Cleaning
{
    /// <summary>
    /// Wiping logic:
    /// - When pointer down, start wipe at pointer location
    /// - If dragging and pointer exit, perform one wipe (lower opacity by one level) until stain is removed
    /// </summary>
    public class StainWipeHandler : PointAndClick
    {
        [Tooltip("How far you have to drag in order to wipe")]
        [SerializeField] public float minWipeDistance = 30f;
        [Tooltip("How many times you need to wipe before removing a stain")]
        [SerializeField] public int numberOfWipes = 5;
        [Tooltip("How low the image color alpha can be before it is removed")]
        [SerializeField] public float stainRemoveAlphaThreshold = 0.3f;

        private RawImage _image;

        private Vector2 _beginWipePos;
        private bool _isWiping;

        // Start is called before the first frame update
        void Start()
        {
            _image = gameObject.GetComponent<RawImage>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            // Keep track of where wiping begins
            _beginWipePos = eventData.position;
            Debug.Log("WIPE: POS " + _beginWipePos);
            Debug.Log("WIPE: STAIN COLOR " + _image.color);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            // Calculate distance dragged
            Vector2 currDragPos = eventData.position;
            float distance = CalculateDistance(_beginWipePos, currDragPos);

            if (distance > minWipeDistance)
            {
                // If dragged over a certain distance, then it is considered wiping
                _isWiping = true;
            }
            else _isWiping = false;
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            _isWiping = false;
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            // Only perform wipe if dragging as well
            if(_isWiping) PerformWipe();
        }

        private void PerformWipe()
        {
            Debug.Log("WIPE: PERFORM");

            Color color = _image.color;

            // If opacity is low enough, remove the gameObject
            // This is so multiple layers of stains can be wiped
            if(color.a <= stainRemoveAlphaThreshold)
            {
                Debug.Log("WIPE: STAIN REMOVED");
                Destroy(gameObject);
                return;
            }

            // Lower image opacity by one level every wipe
            color.a -= color.a / numberOfWipes;
            _image.color = color;
        }

        // Distance formula: sqrt((x2 - x1)^2 + (y2 - y1)^2)
        private float CalculateDistance(Vector2 start, Vector2 end)
        {
            float sqx = Mathf.Pow(end.x - start.x, 2);
            float sqy = Mathf.Pow(end.y - start.y, 2);
            return Mathf.Sqrt(sqx + sqy);
        }
    }
}
