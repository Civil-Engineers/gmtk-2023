using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paw : MonoBehaviour
{
    RectTransform rectTransform;
    public Profile profile;
    float test = -20;
    public float minSwipe = 30f;
    bool click = false;
    
    float firstAngle;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 delta = Input.mousePosition - screenPos;
        float angle = -Vector2.SignedAngle(delta, Vector2.up)+test;
        gameObject.transform.eulerAngles = new Vector3(0, 0, angle);
        if(Input.GetMouseButtonDown(0)) {
            if(-18 < angle && angle < 34.8f) {
                click = true;
                firstAngle = angle;
            }
        } else if (click && Input.GetMouseButton(0)) {
            profile.setPosition(angle-firstAngle);
            if(-18 > angle || angle > 34.8f) {
                checkSwipe(angle);
                click = false;
                profile.resetPosition();
            }
        } else if (click && Input.GetMouseButtonUp(0)) {
            checkSwipe(angle);
            profile.resetPosition();
        }
        // else if()
        // Vector3 v3 = Input.mousePosition;
        // v3.z = 10.0f;
        // v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(v3);
        // rectTransform.rotation = rectTransform.rotation.;
    }

    void checkSwipe(float angle) {
        if (click && Mathf.Abs(angle-firstAngle) > minSwipe) {
            if(angle-firstAngle > 0) {
                // Debug.Log("Nay");
                Debug.Log(!profile.isGood() ? "Correct" : "Wrong");

            } else {
                // Debug.Log("Yay");
                Debug.Log(profile.isGood() ? "Correct" : "Wrong");
            }
            click = false;
            profile.resetPosition();
            profile.setNextProfile();
        } 
    }
}
