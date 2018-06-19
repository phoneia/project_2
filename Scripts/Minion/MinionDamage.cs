using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDamage : MonoBehaviour
{
    public GameObject damageEffect;

    private MinionAnimator anim;
    private MinionState status;

    GameObject parent;

    //private MinionUI minBar;

    //public MainUiBar mainUI;

    void Start()
    {
        anim = GetComponent<MinionAnimator>();
        status = GetComponent<MinionState>();

        //minBar = GameObject.FindGameObjectWithTag("MinUI").GetComponent<MinionUI>();
        //mainUI = GameObject.Find("UI").GetComponent<MainUiBar>();

    }

    public void Update()
    {
        if (status.minstate == MinionState.MinState.Death)
		{
			Destroy(gameObject,1.5f);
			return;
		}

        if (status.CurrentHp <= 0.0f)
        {
            CharacterStates chatacte;
            chatacte = parent.GetComponent<CharacterStates>();

            if ( chatacte != null)
            {
                chatacte.CurrentExp += status.Exp;
                chatacte.CurrentGold += status.Gold;
            }
            


            anim.PlayAnim(MinionState.MinState.Death);
            return;
        }

    }



    public void OnTriggerEnter(Collider other)
    {
        if (status.minstate == MinionState.MinState.Death)
            return;


        if (other.gameObject.tag == "Atk1")// || other.gameObject.tag == "EnemyAtk")
        {
            parent = other.transform.root.gameObject;
            CharacterTotalState tState = parent.GetComponent<CharacterTotalState>();
			//status.CurrentHp--;
			// Debug.Log(tState.Ta);
			// minBar.HpDown(tState.Ta);
            if(tState != null)
            {
                status.CurrentHp -= tState.Ta;
            }
			

            GameObject effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f);

        }

        if (other.gameObject.tag == "Atk2")
        {
            parent = other.GetComponent<MagicDamage>().parent;
        }
        if (other.gameObject.tag == "Atk3")
        {
            parent = other.GetComponent<MagicDamage2>().parent;
        }

        

    }

    // 플레이어 에서 센드 메서지로 이것을 불러 오면서 
    // 값을 주면 된다.
    public void MinDamage(int damage)
    {
        status.CurrentHp -= damage;
    }
}