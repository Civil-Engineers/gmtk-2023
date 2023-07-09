using Peebo.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peebo.Runtime.Game
{
    public class CustomCursorManager : MonoBehaviour
    {
        [Tooltip("Coordinates for cursor click position (default is top left)")]
        [SerializeField] public Vector2 hotSpot = new(0, 0);
        [Tooltip("Sprites to use for default cursor")]
        [SerializeField] public Texture2D[] defaultCursors;

        private IEnumerator _animateCursorCo;
        private int _currentFrame = 0;

        void Start()
        {
            _animateCursorCo = AnimateCursor(defaultCursors);
            StartCoroutine(_animateCursorCo);
        }

        IEnumerator AnimateCursor(Texture2D[] cursors)
        {
            while(cursors.Length > 0)
            {
                _currentFrame = (_currentFrame + 1) % cursors.Length;
                Cursor.SetCursor(cursors[_currentFrame], hotSpot, CursorMode.ForceSoftware);
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void OnCursorChange(CursorEventData eventData)
        {
            Texture2D[] cursorTextures = eventData.Textures;

            StopCoroutine(_animateCursorCo);
            _currentFrame = 0;
            _animateCursorCo = AnimateCursor(cursorTextures);
            StartCoroutine(_animateCursorCo);
        }
    }
}
