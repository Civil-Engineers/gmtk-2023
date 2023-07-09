using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comic1 : MonoBehaviour
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
                    ACamera.Play("I1");
                    comic.Play("IC2");
                    break;
                case 1: 
                    comic.Play("IC3");
                    break;
                case 2: 
                    ACamera.Play("I2");
                    comic.Play("IC4");
                    break;
                case 3: 
                    comic.Play("IC5");
                    break;
                case 4: 
                    comic.Play("IC6");
                    break;
                case 5: 
                    SceneManager.LoadScene("ComicFood");
                    break;
                case 6:
                    //next scene;
                    break;
            }
            index++;
        }
    }
}
