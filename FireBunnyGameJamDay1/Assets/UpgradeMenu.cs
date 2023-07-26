using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
	public NumberManager numberManager;
	[SerializeField]private GameObject waterGenerator;
	[SerializeField]private GameObject oxygenGenerator;
	[SerializeField]private GameObject electricityGenerator;
	
	[SerializeField]private GameObject[] upgradeButtons;
	
	public void timesTwoWater()
	{
		if(numberManager.oxygen < 30 || numberManager.electricity < 30) return;
		waterGenerator.GetComponent<Generator>().waterIncrease *= 2;
		numberManager.oxygen -= 30;
		numberManager.electricity -= 30;
		upgradeButtons[1].SetActive(false);
	}
	
	public void timesTwoOxygen()
	{
		if(numberManager.water < 30 || numberManager.electricity < 30) return;
		oxygenGenerator.GetComponent<Generator>().oxygenIncrease *= 2;
		numberManager.water -= 30;
		numberManager.electricity -= 30;
		upgradeButtons[0].SetActive(false);
	}
	
	public void timesTwoElectricity()
	{
		if(numberManager.oxygen < 30 || numberManager.water < 30) return;
		electricityGenerator.GetComponent<Generator>().electricityIncrease *= 2;
		numberManager.oxygen -= 30;
		numberManager.water -= 30;
		upgradeButtons[2].SetActive(false);
	}
	
	public void increaseResourceCaps()
	{
		if(numberManager.oxygen < 30 || numberManager.water < 30 || numberManager.electricity < 30) return;
		numberManager.waterCap += 50;
		numberManager.oxygenCap += 50;
		numberManager.electricityCap += 50;
		upgradeButtons[3].SetActive(false);
		
		numberManager.water -= 30;
		numberManager.oxygen -= 30;
		numberManager.electricity -= 30;
	}
	
	
	[SerializeField]private GameObject doorOne;
	[SerializeField]private GameObject doorTwo;
	
	public void unlockDoors()
	{
		if(numberManager.oxygen < 30 || numberManager.electricity < 30) return;
		
		doorOne.GetComponent<door>().unlocked = true;
		doorTwo.GetComponent<door>().unlocked = true;
		upgradeButtons[4].SetActive(false);
		
		numberManager.oxygen -= 30;
		numberManager.electricity -= 30;
	}
	
	
}
