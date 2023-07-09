using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                        this.gameObject.SetActive(false);

       wait(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator wait() {

        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(true);
    }

}
