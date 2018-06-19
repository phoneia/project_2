using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
	public static PlayerSelect Instance { get; private set; }

	public string playerName;

	void Awake()
	{
		Instance = this;

		DontDestroyOnLoad(this);
	}
}