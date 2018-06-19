using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
	// 스킬 모두 로드용
	public SkillData[] sList;

	// 스킬 배치용
	public List<SkillData> skill;
	public Transform sParent;
	public SkillSlot[] skillButton;

	private PlayerMoveController controller;
	private CharacterAnimatior animatior;

	public GameObject player;
	public CharacterStates states;
	public int skillSet;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		states = player.transform.GetComponent<CharacterStates>();
		controller = player.GetComponent<PlayerMoveController>();
		animatior = player.GetComponent<CharacterAnimatior>();

		if (sParent != null)
		{
			skillButton = sParent.GetComponentsInChildren<SkillSlot>();
		}
		SetSkill();
	}


	private void SetSkill()
	{

		sList = Resources.LoadAll<SkillData>("Skill");


		if (player.gameObject.name == "Maria(Clone)")
		{
			skillSet = 1;
		}
		if (player.gameObject.name == "Ganfaul(Clone)")
		{
			skillSet = 4;
		}

		for (int i = 0; i < skill.Count; i++)
		{
			skill[i] = sList[skillSet + i];
		}

		for (int i = 0; i < skillButton.Length; i++)
		{
			skillButton[i].SkillData = sList[skillSet + i];
		}

	}

	// 쿨타임 이벤트?
	void Update()
	{
		for (int i = 0; i < skill.Count; i++)
		{
			if (!skill[i].isUseable)
			{
				skillButton[i].image.fillAmount += Time.deltaTime / skill[i].delay;

				if (skillButton[i].image.fillAmount == 1)
				{
					skill[i].isUseable = true;
                    
				}

			}
		}

	}

	public void UsingSkill(int num)
	{
		if (skill[num].isUseable && !states.IsAttack && skill[num].mp <= states.CurrentMp)
		{
			animatior.PlayAnim(CharacterStates.CharState.Attack2 + num);
			skill[num].isUseable = false;
			skillButton[num].image.fillAmount = 0;
            states.CurrentMp -= skill[num].mp;
            skill[num].isDamage = true;
            //states.Att += skill[num].damage;
        }
	}

    public int CulSkill()
    {
        int at = 0;
       
        for (int i = 0; i < skill.Count; i++)
        {
            if(skill[i].isDamage )
            {
                at += skill[i].damage;
                //Debug.Log(at);
                //Debug.Log("i" + i + ": " + skill[i].isDamage);
            }
        }
        return at;
    }

}

