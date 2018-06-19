using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBar : MonoBehaviour
{

    [SerializeField]
    private Image hpImage;

    [SerializeField]
    private TowerState state;

    //[SerializeField]
    //private Transform uiPivot;

    [SerializeField]
    private Text hpText;

    void Start()
    {
        state = transform.root.GetComponent<TowerState>();
        hpImage.enabled = true;
        //uiPivot = GameObject.Find("mUiPivot").transform;
    }

    void Update()
    {
        //transform.position = uiPivot.transform.position;
        //transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        //hpText.text = state.CurrentHp + " / " + state.MaxHp;

        //float hpRemain = (float)state.CurrentHp / state.MaxHp;
        //hpImage.fillAmount = hpRemain;

        //if (state.CurrentHp <= 0)
        //{
        //    state.CurrentHp = 0;
        //    hpImage.enabled = false;
        //}

        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        hpText.text = state.hp + " / " + state.mHp;

        float hpRemain = (float)state.hp / state.mHp;
        hpImage.fillAmount = hpRemain;

        if (state.hp <= 0)
        {
            state.hp = 0;
            hpImage.enabled = false;
        }

    }
}
