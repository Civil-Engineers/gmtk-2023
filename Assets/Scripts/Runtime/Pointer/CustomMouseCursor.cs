using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Pointer
{
    public class CustomMouseCursor : PointAndClick
    {
        [Tooltip("Sprites to use for cursor OnPointerEnter")]
        [SerializeField] public Texture2D[] pointerCursors;
        [Tooltip("Sprites to use for default cursor")]
        [SerializeField] public Texture2D[] defaultCursors;
        [Tooltip("Coordinates for cursor click position (default is top left)")]
        [SerializeField] public Vector2 hotSpot = new(0, 0);

        private IEnumerator _animatePointerCursorCo;
        private IEnumerator _animateDefaultCursorCo;
        private int _currentFrame = 0;

        // Start is called before the first frame update
        void Start()
        {
            _animatePointerCursorCo = AnimateCursor(pointerCursors);
            _animateDefaultCursorCo = AnimateCursor(defaultCursors);
        }

        // Update is called once per frame
        void Update()
        {
        }

        IEnumerator AnimateCursor(Texture2D[] cursors) {
            while(cursors.Length > 0) {
                _currentFrame = (_currentFrame + 1) % cursors.Length;
                Cursor.SetCursor(cursors[_currentFrame], hotSpot, CursorMode.ForceSoftware);
                yield return new WaitForSeconds(0.5f);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            _currentFrame = 0;

            StopCoroutine(_animatePointerCursorCo);
            StartCoroutine(_animateDefaultCursorCo);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            StopCoroutine(_animateDefaultCursorCo);
            StartCoroutine(_animatePointerCursorCo);
        }
    }
}
