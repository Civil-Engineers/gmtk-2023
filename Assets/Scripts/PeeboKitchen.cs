using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Peebo.Runtime.Audio;

public class PeeboKitchen : MonoBehaviour
{
    public Animator animator;
    public Animator girlAnimator;
    int n = 0;

    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        wait();
        girlAnimator.SetBool("IsGrabbing", true);
        FindObjectOfType<AudioManager>().Play("MinigameBG");
    }
    
    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(0)) {
        animator.SetTrigger("Grab");
        girlAnimator.SetBool("HasFood", true);
        girlAnimator.SetBool("IsEating", true);
        done = true;
        n++;
        if(n > 2) {
            SceneManager.LoadScene("ComicMess");
        }
     }
    }

    IEnumerator wait() {
        // errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        // errorText.gameObject.SetActive(false);
    }
}
