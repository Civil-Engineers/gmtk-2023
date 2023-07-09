using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public static AnimationManager Instance { get; private set; }
    public Animator girlAn;
    public Animator peeboAn;

    public bool isGirlGrabbing;
    public bool isPeeboGrabbing;

    void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than one instance!");
        return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool girlHasFood() {
        return girlAn.GetBool("hasFood");
    }

    public bool girlGrabbing() {
        return girlAn.GetBool("isGrabbing");
    }

    public void startGirlGrab() {
        if(!girlHasFood()) {
            girlAn.SetBool("isGrabbing", true);
        }
    }

    public void endGirlGrab(bool isFoodBad, bool hasFood) {
        if (isFoodBad) {
            girlAn.SetBool("IsFoodBad", true);
        }

        if (hasFood) {
            girlAn.SetBool("HasFood", true);
        }
        girlAn.SetBool("IsEating", true);
        waitGirlEating();
        girlAn.SetBool("IsGrabbing", false);
    }

    public void peeboGrab() {
        peeboAn.SetTrigger("Grab");
    }

    IEnumerator waitGirlEating() {
        // errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        // errorText.gameObject.SetActive(false);
    }
}
