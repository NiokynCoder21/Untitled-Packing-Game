using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStorageManager : MonoBehaviour
{
    public float maxGroceries;
    public float currentGroceries;

    void Start()
    {
        currentGroceries = maxGroceries;
    }

    public void LossGroceries(int loss)
    {
        if (currentGroceries <= 5)
        {
            currentGroceries -= loss;
        }
    }
}
