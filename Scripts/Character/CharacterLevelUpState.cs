using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelUpState : MonoBehaviour
{

    [SerializeField] private AnimationCurve levHp;
    [SerializeField] private AnimationCurve levMp;
    [SerializeField] private AnimationCurve levAtt;
    [SerializeField] private AnimationCurve levDef;
    [SerializeField] private AnimationCurve levReq;

    public int LevHp(int level)
    {
        return (int)levHp.Evaluate(level);
    }
        
    public int LevMp(int level)
    {
        return (int)levMp.Evaluate(level);
    }

    public int LevAtt(int level)
    {
        return (int)levAtt.Evaluate(level);
    }

    public int LevDef(int level)
    {
        return (int)levDef.Evaluate(level);
    }

    public int LevReq (int level)
    {
        return (int)levReq.Evaluate(level);
    }

}
