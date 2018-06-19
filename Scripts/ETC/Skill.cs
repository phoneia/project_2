using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
	public float coolTime = 2.0f;
	public Image button;

	private PlayerMoveController player;

    

    void Awake()
	{
		player = GetComponent<PlayerMoveController>();
	}

	void Update()
	{
		//if(button.fillAmount !=0)
		//{
		//	button.fillAmount -= Time.deltaTime / coolTime;
		//}
	}

	public void SkillCool()
	{
		//if(button.fillAmount == 0)
		//{
		//	button.fillAmount = 1.0f;
		//	player.OnSkill1();
		//}
	}
}
