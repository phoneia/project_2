using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAnimator : MonoBehaviour
{
    private MinionState status;
    private Animator anim;
    private MinionController controller;

    void Start()
    {
        status = GetComponent<MinionState>();
        anim = GetComponent<Animator>();
    }

    public bool IsPlayAnim(string name, int layer = 0)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsName(name))
        {
            return true;
        }

        return false;
    }

    public void PlayAnim(MinionState.MinState state)
    {
        status.minstate = state;
        switch (state)
        {
            case MinionState.MinState.Idle:
                anim.SetBool("Move", false);
                break;

            case MinionState.MinState.Move:
                anim.SetBool("Move", true);
                break;

            case MinionState.MinState.Attack:
                anim.SetTrigger("Attack");
                break;

            case MinionState.MinState.Death:
                anim.SetTrigger("Death");
                GetComponent<Collider>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                break;
        }
    }
}