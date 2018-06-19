using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenHMP : MonoBehaviour
{
    private CharacterStates state;

    void Awake()
    {
        state = GetComponent<CharacterStates>();
    }

    void Update()
    {

        if (state.CurrentHp <= state.MaxHp)
        {
            state.CurrentHp += (int)(state.RegemHp * Time.deltaTime);

            if (state.CurrentHp >= state.MaxHp)
                state.CurrentHp = state.MaxHp;
        }

        if (state.CurrentMp <= state.MaxMp)
        {
            state.CurrentMp += (int)(state.RegemMp * Time.deltaTime);

            if(state.CurrentMp >= state.MaxMp)
                state.CurrentMp = state.MaxMp;
        }
    }
}



// 초당 회복량
// 10 이면 1초에 10 회복
// 300 이변 1초에 300 회복
// 초마다 숫자가 한번에 증가되는 것이 아니고
// 프레임 마다 회복 되게 만든다면=