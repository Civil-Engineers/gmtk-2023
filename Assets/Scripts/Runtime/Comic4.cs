using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic4 : MonoBehaviour
{
    int index = 0;
    public Animator comic;
    public Animator ACamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            switch(index) {
                case 0:       
                    comic.Play("IC2");
                    break;
                case 1: 
                    ACamera.Play("L1");
                    comic.Play("IC3");
                    break;
                case 2: 
                    comic.Play("IC4");
                    break;
                case 3: 
                    ACamera.Play("L2");
                    comic.Play("IC5");
                    break;
                case 4: 
                    comic.Play("IC6");
                    break;
                case 5:
                    SceneManager.LoadScene("LOVE");
                    break;
            }
            index++;
        }
    }
}
