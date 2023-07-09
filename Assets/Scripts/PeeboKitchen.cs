using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeboKitchen : MonoBehaviour
{
    public Animator animator;
    public Animator girlAnimator;

    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        wait();
        girlAnimator.SetBool("IsGrabbing", true);
    }
    
    // Update is called once per frame
    void Update()
    {
     if (Input.GetButtonDown("Jump")) {
        animator.SetTrigger("Grab");
        girlAnimator.SetBool("HasFood", true);
        girlAnimator.SetBool("IsEating", true);
        done = true;
     }
    }

    IEnumerator wait() {
        // errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        // errorText.gameObject.SetActive(false);
    }
}
