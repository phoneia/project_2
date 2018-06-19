using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserState : Photon.MonoBehaviour
{
	[SerializeField]
	private CharacterStates state;

	[SerializeField]
	private RawImage image;

	[SerializeField]
	private string playerName;

	[SerializeField]
	private Text nameText;

	void Start()
	{
		state = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStates>();
		image = GameObject.Find("Cam").GetComponent<RawImage>();

		playerName = photonView.owner.NickName;
		nameText.text = playerName;
	}
}
