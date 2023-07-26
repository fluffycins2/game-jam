using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{

	public int oxygen = 100;
	public int electricity = 100;
	public int water = 100;
	
	public int oxygenCap = 100;
	public int electricityCap = 100;
	public int waterCap = 100;
	

	public int oxygenDecreaseRate = 1;
	public int electricityDecreaseRate = 1;
	public int waterDecreaseRate = 1;

	//text
	[SerializeField]
	private Text oxygenText;
	[SerializeField]
	private Text electricityText;
	[SerializeField]
	private Text waterText;
	[SerializeField] GameObject warningText;
	
	
	[SerializeField] GameObject dieText;
	
	//For Increasing difficulty
	[SerializeField] int decayMultiplier = 1;
	[SerializeField]private int increaseDecayRateTime = 5;
	

	
	// Time in between decreases
	private WaitForSeconds waitTime = new WaitForSeconds(2f);

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(DecreaseOxygen());
		StartCoroutine(DecreaseElectricity());
		StartCoroutine(DecreaseWater());
		StartCoroutine(IncreaseDecayRate());
	}

	// Update is called once per frame
	void Update()
	{
		//if a stat is above its cap it gets set to cap size
		if(oxygen > oxygenCap) oxygen = oxygenCap;
		if(electricity > electricityCap) electricity = electricityCap;
		if(water > waterCap) water = waterCap;
		
		// Set text to show int values
		oxygenText.text = "oxygen: " + oxygen.ToString();
		electricityText.text = "electricity: " + electricity.ToString();
		waterText.text = "water " + water.ToString();
		
		// check if stats are low then warn player
		if(oxygen < 30 || water < 30 || electricity < 30) warningText.SetActive(true); else warningText.SetActive(false);
		
		// Check if stats are 0
		if(oxygen <= 0|| water <= 0)
		{
			Die();
		}
	}
	
	
	//Ends the game... well kinda did not complete it yet
	private void Die()
	{
		dieText.SetActive(true);
	}
	
	
	//used for meteor event
	public void ChangeOxygenDecreaseRate(int rate)
	{
		oxygenDecreaseRate = rate;
	}

	// Coroutine to decrease oxygen every second
	private IEnumerator DecreaseOxygen()
	{
		while (oxygen > 0)
		{
			yield return waitTime;
			oxygen -= oxygenDecreaseRate * decayMultiplier;
		}
	}

	// Coroutine to decrease electricity every second
	private IEnumerator DecreaseElectricity()
	{
		while (electricity > 0)
		{
			yield return waitTime;
			electricity -= electricityDecreaseRate * decayMultiplier;
		}
	}

	// Coroutine to decrease water every second
	private IEnumerator DecreaseWater()
	{
		while (water > 0)
		{
			yield return waitTime;
			water -= waterDecreaseRate * decayMultiplier;
		}
	}
	
	
	//Increases Decay rate to increase difficulty 
	private IEnumerator IncreaseDecayRate()
	{
		while(increaseDecayRateTime > 0)
		{
			yield return waitTime;
			increaseDecayRateTime--;
		}
		
		increaseDecayRateTime = 90;
		decayMultiplier += 1;
		StartCoroutine(IncreaseDecayRate());
	}
	
	
}
