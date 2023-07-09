using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class FoodGame : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject[] foodPrefabs;

    GameObject currentFood;
    FoodType currentFoodType;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine: ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            // search for food animation
            yield return new WaitForSeconds(1);
            currentFood = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], spawnLocation);
            currentFoodType = currentFood.GetComponent<Food>().foodType;

            // wait for click
            yield return new WaitForSeconds(2);
            if (currentFood == null)
            {
                // dont eat food anymation
                // user clicked on the food
            }
            else
            {
                // eat food animation
                Destroy(currentFood);
            }

            // wait for animation
            yield return new WaitForSeconds(2);
        }
    }
}



/**
serach for food
show food
food goes away
show good or bad animation
serach for food
show food
*/
