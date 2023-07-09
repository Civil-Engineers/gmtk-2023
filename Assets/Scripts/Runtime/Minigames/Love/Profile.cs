using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{
    Vector3 initPosition;
    Quaternion initRotation;

    public List<Sprite> sprites;
    public List<bool> isProfileGood;
    public int index = 0;
    // bool ready = true;
    public float test = -.2f;
    UnityEngine.UI.Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<UnityEngine.UI.Image>();
        initPosition = transform.position;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool setNextProfile() {
        index++;
        if(index < sprites.Count) {
            img.sprite = sprites[index];
            return true;
        } else {
            index = 0;
            img.sprite = sprites[index];
            SceneManager.LoadScene("ComicEnd");
            return false;
        }
    }

    public bool isGood() {
        return  index < isProfileGood.Count && isProfileGood[index];
    }

    public void setPosition(float change) {
        Vector3 next = initPosition + new Vector3(change*test,0,0);
        transform.position = next;
        float rotate = change*.5f;
        transform.rotation = initRotation * Quaternion.Euler(Vector3.forward*rotate);
    }
    public void resetPosition() {
        transform.position = initPosition;
        transform.rotation = initRotation;
    }
}
