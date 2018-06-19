using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatior : MonoBehaviour
{
	private CharacterStates status;
	private Animator anim;

	void Start()
	{
		status = GetComponent<CharacterStates>();
		anim = GetComponent<Animator>();
	}

	public bool IsPlayAnim(string name, int layer = 0)
	{
		if(anim.GetCurrentAnimatorStateInfo(layer).IsName(name))
		{
			return true;
		}

		return false;
	}

	public void PlayAnim(CharacterStates.CharState state)
	{
		status.charstate = state;
		switch (state)
		{
			case CharacterStates.CharState.Idle:
				anim.SetBool("Move", false);
                anim.SetBool("Atk1", false);
               
                status.IsAttack = false;
                break;

			case CharacterStates.CharState.Move:
				anim.SetBool("Move", true);
                anim.SetBool("Atk1", false);
               
                status.IsAttack = false;
                break;

			case CharacterStates.CharState.Attack1:
                anim.SetBool("Atk1", true);
                status.IsAttack = true;
                status.Speed = 0.0f;
                break;

			case CharacterStates.CharState.Attack2:
				anim.SetTrigger("Atk2");
                status.IsAttack = true;
                status.Speed = 0.0f;
                break;

			case CharacterStates.CharState.Attack3:
				anim.SetTrigger("Atk3");
                status.IsAttack = true;
                status.Speed = 0.0f;
                break;

			case CharacterStates.CharState.Attack4:
				anim.SetTrigger("Atk4");
                status.IsAttack = true;
                status.Speed = 0.0f;
                break;

			case CharacterStates.CharState.Death:
				anim.SetTrigger("Death");
                break;
		}
	}
}