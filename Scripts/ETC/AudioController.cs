using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	public AudioSource audsrc;
	public Slider volume;
	
	// Use this for initialization
	void Awake()
	{
		volume.value = 1.0f;
		//volume.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		audsrc.volume = volume.value;
	}

	public void SoundOption()
	{
		volume.gameObject.SetActive(true);
	}
}
