using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private Text time;
	float hours = 0.0f;
	int min = 0;

	void Awake()
	{
		time = GetComponent<Text>();
	}

	void Update()
	{
		hours += Time.deltaTime;
		if (hours >= 60)
		{
			min++;
			hours -= 60;
		}

		time.text = string.Format("{0:D2} : {1:D2}", min, (int)hours);
	}
}