using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
	public bool unlocked;
	[SerializeField]private bool inRange;
	
	[SerializeField]private Transform start;
	[SerializeField]private Transform end;
	[SerializeField]private GameObject doorObj;
	private void Start()
	{
		start.position = transform.position;
	}
	
	private void Update() {
		if(inRange)
		{
			doorObj.transform.position = Vector2.Lerp(doorObj.transform.position, end.position, Time.deltaTime);
		}
		
		if(!inRange)
		{
			doorObj.transform.position = Vector2.Lerp(doorObj.transform.position, start.position, Time.deltaTime);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Check for the player
		if (other.CompareTag("Player") && unlocked)
		{
			inRange = true;
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		// Check for the player
		if (other.CompareTag("Player") && unlocked)
		{
			inRange = false;
		}
	}
}
