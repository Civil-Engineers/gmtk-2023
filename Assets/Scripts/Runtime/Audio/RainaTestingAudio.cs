using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Peebo.Runtime.Audio;


public class RainaTestingAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("ComicBG");
    }

    void Update()
    {
        //FindObjectOfType<AudioManager>().Play("SwipeRight");
        //FindObjectOfType<AudioManager>().Play("SwipeLeft");
        //FindObjectOfType<AudioManager>().Play("GarbageCrash");
        //FindObjectOfType<AudioManager>().Play("FloorWipe");
        //FindObjectOfType<AudioManager>().Play("FridgeRustle");
        //FindObjectOfType<AudioManager>().Play("Eating");
    }

}
