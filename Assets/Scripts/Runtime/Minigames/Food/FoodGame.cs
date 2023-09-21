using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodGame : MonoBehaviour
{
    [SerializeField] private SpriteRenderer foodImage;
    [SerializeField] private FoodGenerator foodGen;

    private Food[] randomFoods; 
    private Food currentFood;

    private int numFoods = 5;
    private int foodItr = 0;

    private bool waiting = true;
    private bool seeFood = false;
    private int n = 0;

    private bool girlGrabbing = false;

    private AnimationManager am;

    // Start is called before the first frame update
    void Start()
    {
        // GenerateFood();
        setImageAlpha(foodImage, 0);
        am = AnimationManager.Instance;
        GenerateFood();
        StartCoroutine(routine: ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            am.peeboGrab();
            if(seeFood) {
                toggleFood();
            }
        }

        // if (foodItr < numFoods) {
        //     if (waiting) {
        //         // yield return new WaitForSeconds(4f);
        //         waiting = false;
        //     } else {
        //         am.startGirlGrab();
        //         girlGrabbing = true;
        //         // yield return new WaitForSeconds(4f);
        //         toggleFood();
        //         Debug.Log("hi");
        //     }
        // }
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            if (foodItr < numFoods) {
                // check if food
            }

 
            am.startGirlGrab();
            girlGrabbing = true;
            
            
            // search for food animation
            // yield return new WaitForSeconds(); // need to write a better way to sync with animations
            if(!seeFood) {
                toggleFood();
            }

            // currentFood = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], spawnLocation);
            // currentFoodType = currentFood.GetComponent<Food>().foodType;

            // wait for click
            yield return new WaitForSeconds(2);
            // if (currentFood == null)
            am.endGirlGrab(currentFood.isBad, seeFood);
            if(seeFood) {
                toggleFood();
            }

            // wait for animation
            yield return new WaitForSeconds(2.6f);
        }
    }

    private void GenerateFood() {
        randomFoods = foodGen.Generate(numFoods);
        currentFood = randomFoods[0];
        foodImage.sprite = currentFood.sprite;
    }

    private void nextFood() {
        if (foodItr < numFoods) {
            // check if food
            foodItr++;
        }
        currentFood = randomFoods[foodItr];
        foodImage.sprite = currentFood.sprite;
    }

    private void toggleFood() {
        if (seeFood) {
            setImageAlpha(foodImage, 0);
        } else {
            nextFood();
            setImageAlpha(foodImage, 1);
        }
        seeFood = !seeFood;
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

    private void setImageAlpha(SpriteRenderer img, int alpha) {
        Color col = img.color;
        col.a = alpha;
        img.color = col;
    }
}
