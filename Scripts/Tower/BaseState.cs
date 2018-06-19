using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{

    public int hp;
    public int mHp;

    private bool isDeath;

    public bool IsDeath
    {
        get { return isDeath; }
        set { isDeath = value; }
    }


    //public CharacterStates stat;

    void Start()
    {
        //stat = GetComponent<CharacterStates>();
    }

    void Update()
    {
        //if (stat.CurrentHp <=0)
        //{
        //    stat.charstate = CharacterStates.CharState.Death;
        //    Destroy(this.gameObject, 3);
        //}

        if (hp <= 0)
        {
            isDeath = true;
            Destroy(this.gameObject, 3);
        }
    }

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

            hp -= minState.Att;
        }


    }
}
