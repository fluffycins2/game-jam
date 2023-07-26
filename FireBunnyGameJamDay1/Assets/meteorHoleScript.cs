using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorHoleScript : MonoBehaviour
{
	
	[SerializeField]private GameObject tutorialText;
	private bool inRange;
	
	[SerializeField]private GameObject MeteorManager;
	
	
	[SerializeField]private float holdTimeThreshold = 4.0f; 
	private bool isKeyHeld = false;
	private float timeHeld = 0f;


	// Update is called once per frame
	void Update()
	{
		
		//Checks if space is held to fix the hole
		if (inRange && Input.GetKeyDown(KeyCode.Space))
		{
			isKeyHeld = true;
			timeHeld = 0f;
		}

		if (inRange && Input.GetKeyUp(KeyCode.Space))
		{
			isKeyHeld = false;
			timeHeld = 0f;
		}
		
		if (isKeyHeld)
		{
			timeHeld += Time.deltaTime;
			if (timeHeld >= holdTimeThreshold)
			{
				//triggers the fixedhole void to reset the event
				MeteorManager.GetComponent<meteorEventManager>().FixedHole();
			}
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Check for the player
		if (other.CompareTag("Player"))
		{
			
			tutorialText.SetActive(true);
			inRange = true;
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		// Check for the player
		if (other.CompareTag("Player"))
		{
			
			tutorialText.SetActive(false);
			inRange = false;
			
			
		}
	}
	
	
	
	public void playSound()
	{
		this.gameObject.GetComponent<AudioSource>().Play();
	}
}
