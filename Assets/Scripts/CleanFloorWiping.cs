using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CleanFloorWiping : PointAndClick
{
    [Tooltip("How far you have to drag in order to wipe")]
    [SerializeField] public float minWipeDistance = 50f;

    private Vector2 _beginDragPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        // Keep track of where dragging began
        _beginDragPos = eventData.position;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        // Calculate distance dragged
        Vector2 currDragPos = eventData.position;
        float distance = CalculateDistance(_beginDragPos, currDragPos);

        if(distance > minWipeDistance)
        {
            // If dragged over a certain distance, then execute logic
            Debug.Log("Wiping " + gameObject.name);
        }
    }

    // Distance formula: sqrt((x2 - x1)^2 + (y2 - y1)^2)
    private float CalculateDistance(Vector2 start, Vector2 end)
    {
        float sqx = Mathf.Pow(end.x - start.x, 2);
        float sqy = Mathf.Pow(end.y - start.y, 2);
        return Mathf.Sqrt(sqx + sqy);
    }
}
