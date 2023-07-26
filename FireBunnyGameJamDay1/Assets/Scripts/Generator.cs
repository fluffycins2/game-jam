using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
	private BoxCollider2D trigger;
	private bool inRange;
	public GameObject visualCue;
	public GameObject tutorialText;
	public NumberManager NumberManager;
	private AudioSource audioSource;

	// Amount that this generator refuels
	[SerializeField]
	public int oxygenIncrease;
	[SerializeField]
	public int electricityIncrease;
	[SerializeField]
	public int waterIncrease;
	
	
	
	//Stuff For cooldown
	[SerializeField]private bool onCoolDown;
	[SerializeField]private int coolDownNum;
	[SerializeField]private GameObject coolDownText;


	// Start is called before the first frame update
	void Start()
	{
		// Find the box collider
		trigger = this.GetComponent<BoxCollider2D>();
		// Find the audio source
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (inRange && Input.GetKeyDown(KeyCode.Space) && !onCoolDown)
		{
			// Play audio
			audioSource.Play();
			// Adds to meters depending on what the generator is
			NumberManager.oxygen = NumberManager.oxygen + oxygenIncrease;
			NumberManager.electricity = NumberManager.electricity + electricityIncrease;
			NumberManager.water = NumberManager.water + waterIncrease;
			
			
			// Activates Cool down
			onCoolDown = true;
			coolDownNum = 3;
			StartCoroutine(CoolDown());
		}
		
		
		//Cool down text
		if(inRange && Input.GetKeyDown(KeyCode.Space) && onCoolDown)
		{
			coolDownText.SetActive(true);
		}
		if(inRange && !onCoolDown)
		{
			coolDownText.SetActive(false);
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
			
			//hides cooldown text
			if(coolDownText.activeInHierarchy) coolDownText.SetActive(false);
		}
	}
	
	
	
	private WaitForSeconds waitTime = new WaitForSeconds(1f);
	
	private IEnumerator CoolDown()
	{
		
		//Decrease cooldown by 1 every second for five seconds
		while(coolDownNum > 0)
		{
			yield return waitTime;
			coolDownNum -= 1;
		}
		//if cooldown is done set onCoolDown to false
		if(coolDownNum == 0)
		{
			
			onCoolDown = false;
		}
	}
}

