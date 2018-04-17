using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackHealthBar : MonoBehaviour {

	public float percentHealth;
	public GameObject background;

	// Use this for initialization
	void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (percentHealth >= 1.0f)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			background.GetComponent<SpriteRenderer>().enabled = false;
		} 
		else
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			background.GetComponent<SpriteRenderer>().enabled = true;
			transform.localPosition = new Vector3(0.5f * percentHealth - 0.5f, transform.localPosition.y, transform.localPosition.z);
			transform.localScale = new Vector3(percentHealth, transform.localScale.y, transform.localScale.z);
		}
	}
}
