using System.Collections;
using System.Collections.Generic;
using Peebo.Runtime.Pointer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fling : PointAndClick
{

    public float powerMultiplier = 0.5f;
    public float scaleIndicatorMultiplier = 0.2f;
    Vector2 downPosition;
    Vector2 secondaryPosition;

    public RectTransform powerIndicator;
    Rigidbody2D rigidbody2D;

    Vector2 delta;
    bool pointerDown = false;
    private Outline _outline;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _outline = gameObject.GetComponent<Outline>();
        _outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            Vector2 screenPos = camera.WorldToScreenPoint(powerIndicator.position);
            delta = secondaryPosition - screenPos;
            powerIndicator.eulerAngles = new Vector3(0, 0, -Vector2.SignedAngle(delta, Vector2.right));
            powerIndicator.gameObject.SetActive(true);
            Vector3 scale = powerIndicator.localScale;
            scale.x = delta.magnitude * scaleIndicatorMultiplier;
            powerIndicator.localScale = scale;
            float magnitude = delta.magnitude;

        }
        else
        {
            powerIndicator.gameObject.SetActive(false);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        secondaryPosition = eventData.position;
        pointerDown = true;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        downPosition = eventData.position;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        pointerDown = false;

        rigidbody2D.AddForce(-delta * powerMultiplier, ForceMode2D.Impulse);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        // Enable outline component
        _outline.enabled = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // Turn off outline
        _outline.enabled = false;
    }
}
