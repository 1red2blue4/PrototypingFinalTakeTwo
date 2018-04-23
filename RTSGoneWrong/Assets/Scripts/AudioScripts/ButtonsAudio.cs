using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsAudio : MonoBehaviour, IPointerEnterHandler {

	[SerializeField] private AudioSource hoverSound;
	[SerializeField] private AudioSource clickSound;

	void Start()
	{
		gameObject.GetComponent<Button>().onClick.AddListener(DoThingOnClick);
	}

	public void OnPointerEnter(PointerEventData data)
	{
		print("Yay!");
		hoverSound.Play();
	}

	public void DoThingOnClick()
	{
		clickSound.Play();
	}

}
