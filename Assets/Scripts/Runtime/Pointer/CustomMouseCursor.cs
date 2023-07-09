using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Peebo.Runtime.Pointer
{
    public class CustomMouseCursor : PointAndClick
    {
        [SerializeField] public Texture2D[] mouseCursor;
        [SerializeField] public Texture2D[] defaultCursor;
        [SerializeField] public float frameRate;

        private IEnumerator animateHoverCoroutine;
        private IEnumerator animateDefaultCoroutine;
        private int currentFrame = 0;

        Vector2 hotSpot = new Vector2(0, 0);

        // Start is called before the first frame update
        void Start()
        {
            animateHoverCoroutine = AnimateCursor(mouseCursor);
            animateDefaultCoroutine = AnimateCursor(defaultCursor);
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        IEnumerator AnimateCursor(Texture2D[] cursorArray) {
            currentFrame = 0;
            while(true) {
                currentFrame = (currentFrame + 1) % cursorArray.Length;
                Cursor.SetCursor(cursorArray[currentFrame], hotSpot, CursorMode.ForceSoftware);
                yield return new WaitForSeconds(0.5f);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            StopCoroutine(animateHoverCoroutine);
            StartCoroutine(animateDefaultCoroutine);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            StopCoroutine(animateDefaultCoroutine);
            StartCoroutine(animateHoverCoroutine);
        }
    }
}
