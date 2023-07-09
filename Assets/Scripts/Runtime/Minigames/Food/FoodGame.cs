using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodGame : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image foodImage;
    [SerializeField] private FoodGenerator foodGen;

    private Food[] randomFoods; 
    private Food currentFood;

    private int numFoods = 5;
    private int foodItr = 0;

    private bool waiting = true;
    private bool seeFood = false;
    private int n = 0;

    private bool girlGrabbing = false;

    private AnimationManager am = AnimationManager.Instance;

    // Start is called before the first frame update
    void Start()
    {
        // GenerateFood();
        setImageAlpha(foodImage, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            am.peeboGrab();
            n++;
            Debug.Log("asdf");
        }
        if(n > 2) {
            SceneManager.LoadScene("ComicMess");
        }

        //  if (Input.GetMouseButtonDown(0)) {
        //     am.peeboGrab();
        //  }

        // if (foodItr < numFoods) {
        //     if (waiting) {
        //         wait();
        //         waiting = false;
        //     } else {
        //         am.startGirlGrab();
        //         girlGrabbing = true;
        //         waitFood();
        //         toggleFood();
        //     }
        // }
    }

    // private void GenerateFood() {
    //     randomFoods = foodGen.Generate(numFoods);
    //     currentFood = randomFoods[0];
    //     foodImage.sprite = currentFood.Image;
    // }

    private void nextFood() {
        currentFood = randomFoods[foodItr];
        foodImage.sprite = currentFood.Image;
    }

    private void toggleFood() {
        if (seeFood) {
            setImageAlpha(foodImage, 0);
        } else {
            setImageAlpha(foodImage, 1);
        }
    }

    bool isFoodBad() {
        return currentFood.isBad;
    }
    IEnumerator wait() {
        // errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        // errorText.gameObject.SetActive(false);
    }

    IEnumerator waitFood() {
        yield return new WaitForSeconds(1f);
    }

    private void setImageAlpha(UnityEngine.UI.Image img, int alpha) {
        Color col = img.color;
        col.a = alpha;
        img.color = col;
    }
}
