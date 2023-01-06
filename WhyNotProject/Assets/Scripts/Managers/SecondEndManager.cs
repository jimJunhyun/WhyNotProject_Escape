using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SecondEndManager : MonoBehaviour
{
	public static SecondEndManager instance;

	[SerializeField] private PressKeyChecker pressKeyChecker;
    public int weightedCoins = 5;
    [HideInInspector] public int insertedWeightedCoins = 0;
    [HideInInspector] public bool isChecking = true;

    private void Awake()
    {
		instance = this;
    }

    public void WeightCoinInserted()
	{
        insertedWeightedCoins += 1;
		if (isChecking)
		{
			if (weightedCoins == insertedWeightedCoins)
			{
				OptionUI.instance.isHappyEnd = false;

				pressKeyChecker.OnMatched?.Invoke();
			}
		}
        
	}

    public void DisableCondition()
	{
		isChecking = false;
	}
}
