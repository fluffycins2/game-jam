using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeStation : MonoBehaviour
{
	
	private bool inRange;
	public GameObject visualCue;
	public GameObject tutorialText;
	
	[SerializeField] GameObject upgradeMenuUI;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (inRange && Input.GetKeyDown(KeyCode.Space))
		{
			upgradeMenuUI.SetActive(true);
		}
	}
	
	
	
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Check for the player
		if (other.CompareTag("Player"))
		{
			visualCue.SetActive(true);
			tutorialText.SetActive(true);
			inRange = true;
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		// Check for the player
		if (other.CompareTag("Player"))
		{
			visualCue.SetActive(false);
			tutorialText.SetActive(false);
			inRange = false;
			upgradeMenuUI.SetActive(false);
		}
	}
}
