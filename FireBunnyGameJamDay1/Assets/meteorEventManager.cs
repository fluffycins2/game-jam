using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meteorEventManager : MonoBehaviour
{
	[SerializeField]private GameObject[] holes;
	
	[SerializeField]private GameObject NumberManager;
	
	[SerializeField]private GameObject fixTheHoleText;
	
	[SerializeField]private float[] eventTimeRange;
	
	[SerializeField]private GameObject cameraShake;
	
	private float eventTime;
	private int holesIndex;
	
	// Start is called before the first frame update
	void Start()
	{
		//starts the first meteor event countdown
		eventTime = Random.Range(eventTimeRange[0],eventTimeRange[1]);
		StartCoroutine(meteorEventWaitTime());
	}
	
	

	//Starts Event
	private void MeteorEvent()
	{
		//Shows/Spawns the hole from a range of game objects already in the scene
		holesIndex = Random.Range(0, holes.Length);
		
		holes[holesIndex].SetActive(true);
		holes[holesIndex].GetComponent<meteorHoleScript>().playSound();
		fixTheHoleText.SetActive(true);
		cameraShake.GetComponent<CameraShake>().ShakeCamera();
		NumberManager.GetComponent<NumberManager>().ChangeOxygenDecreaseRate(3);
	}
	
	
	//Resets event
	public void FixedHole()
	{
		//Hides hole and text
		holes[holesIndex].SetActive(false);
		fixTheHoleText.SetActive(false);
		
		//Resets Oxygen Decrease rate
		NumberManager.GetComponent<NumberManager>().ChangeOxygenDecreaseRate(1);
		
		//Restarts the event timer
		eventTime = Random.Range(eventTimeRange[0],eventTimeRange[1]);
		StartCoroutine(meteorEventWaitTime());
	}
	
	
	
	//Event Timer
	private IEnumerator meteorEventWaitTime()
	{
		//Starts countdown untill event happens
		while(eventTime > 0)
		{
			yield return new WaitForSeconds(1f);
			eventTime -= 1;
		}
		
		MeteorEvent();
	}
}
