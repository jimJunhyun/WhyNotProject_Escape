using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SecondEndManager : MonoBehaviour
{
    public int weightedCoins = 5;
    int insertedWeightedCoins = 0;
    bool isChecking = true;

    public void WeightCoinInserted()
	{
        insertedWeightedCoins += 1;
		if (isChecking)
		{
			if (weightedCoins == insertedWeightedCoins)
			{
				SceneManager.LoadScene("EndScene");
			}
		}
        
	}

    public void DisableCondition()
	{
		isChecking = false;
	}
}
