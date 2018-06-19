using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : Photon.MonoBehaviour
{
	private	CharacterUI charBar;
	private MainUiBar mainUI;

	private CharacterAnimatior anim;
	private CharacterStates status;
	private MinionAnimator mAnim;
	
	void Start()
	{
		anim = GetComponent<CharacterAnimatior>();
		status = GetComponent<CharacterStates>();
		mAnim = GetComponent<MinionAnimator>();

		charBar = GameObject.FindGameObjectWithTag("CharUI").GetComponent<CharacterUI>();
		mainUI = GameObject.Find("UI").GetComponent<MainUiBar>();
	}

    // 몬스터 센트메세지를 여기서 준다.
    // MinDamage
    // colliders 로 받아..범의 안에 있는 모든 것에 대미지를 준다.
    // 범의 공격 구현 
    // 공격 범위를 만들어 줘야 한다.
	public void OnTriggerEnter(Collider other)
	{
        GameObject parent = other.transform.root.gameObject;
        MinionState minState = parent.GetComponent<MinionState>();

        if (other.gameObject.tag == "EnemyAtk")
		{
			//if(PhotonNetwork.isMasterClient)
			//{
			//	photonView.RPC("Damage", PhotonTargets.AllViaServer);
			//}

			Damage(minState.Att - status.Def);
		}
	}

	[PunRPC]
	public void Damage(int damage)
	{
        // charBar.HpDown();
        // mainUI.HpDown();

        status.CurrentHp -= damage;
        // status.CurrentHp -= 1;

        if (status.CurrentHp <= 0)
		{
			anim.PlayAnim(CharacterStates.CharState.Death);
           
			return;
		}
	}

    
}