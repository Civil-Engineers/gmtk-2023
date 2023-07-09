using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FoodGenerator : ScriptableObject
{
    private System.Random random = new System.Random();

    public Food[] goodFoods;
    public Food[] badFoods;
    private int minBad = 2; 

    private int totalGood = 9;
    private int totalBad = 7;

    public static int index = 0;

    public Food[] Generate(int numFoods) {
    // randomize how many bads (from range of 0 to whatever)
    // randomize both lists
    // pick x bad and pick total-x good
    // then randomize again

        int numBad = Random.Range(minBad, numFoods-minBad);
        int numGood = numFoods-numBad;
        int totalFoods = (totalGood + totalBad);
        
        if (numFoods > totalFoods || numGood > totalGood || numBad > totalBad) {
            Debug.Log("invalid size for food gen array");
            return null;
        }

        Food[] randomFoods = new Food[numFoods];

        Shuffle(badFoods);
        Shuffle(goodFoods);
        
        for (int i = 0; i < numBad; i++) {
            randomFoods[i] = badFoods[i]; // pick bad foods
        }
        for (int j = numBad; j < numFoods; j++) {
            randomFoods[j] = goodFoods[j-numBad]; // pick good foods
        }

        Shuffle(randomFoods);
        return randomFoods; 
    }

    void Shuffle(Food[] array) {
        int size = array.Length;
         for (int i = size-1; i > 0; i--) {
           int ran = random.Next(0, i);
           Food f = array[ran];
           array[ran] = array[i];
           array[i] = f;
        }
    }
}
