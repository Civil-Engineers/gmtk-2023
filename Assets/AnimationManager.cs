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
        return girlAn.GetBool("HasFood");
    }

    public bool girlGrabbing() {
        return girlAn.GetBool("IsGrabbing");
    }

    public void startGirlGrab() {
        girlAn.SetBool("IsGrabbing", true);
        girlAn.SetBool("HasFood", false);
    }

    public void endGirlGrab(bool isFoodBad, bool hasFood) {
        girlAn.SetBool("IsFoodBad", isFoodBad);
        girlAn.SetBool("HasFood", hasFood);
        
        girlAn.SetBool("IsEating", true);
        waitGirlEating();
        StartCoroutine(routine: waitGirlEating());
    }

    public void peeboGrab() {
        peeboAn.SetTrigger("Grab");
    }

    IEnumerator waitGirlEating() {
        // errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        girlAn.SetBool("IsGrabbing", false);
        girlAn.SetBool("IsEating", false);
        // errorText.gameObject.SetActive(false);
    }
}
