using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionUI : MonoBehaviour
{
	[SerializeField]
	private Image hpImage;

	[SerializeField]
	private MinionState state;

	//[SerializeField]
	//private Transform uiPivot;

	[SerializeField]
	private Text hpText;

	void Start()
	{
		state = transform.root.GetComponent<MinionState>();
        hpImage.enabled = true;
        //uiPivot = GameObject.Find("mUiPivot").transform;
    }

	void Update()
	{
		//transform.position = uiPivot.transform.position;
		transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

		hpText.text = state.CurrentHp + " / " + state.MaxHp;

        float hpRemain = (float)state.CurrentHp / state.MaxHp;
        hpImage.fillAmount = hpRemain;

        if(state.CurrentHp <=0)
        {
            state.CurrentHp = 0;
            hpImage.enabled =false;
        }

    }

	//public int HpDown(int damage)
	//{
	//	state.CurrentHp -= damage;
    //
	//	float hpRemain = (float)state.CurrentHp / state.MaxHp;
	//	hpImage.fillAmount = hpRemain;
    //
	//	return state.CurrentHp;
	//}
    //
	//public void SetHp(int hp)
	//{
	//	state.CurrentHp = hp;
    //
	//	float hpRemain = (float)state.CurrentHp / state.MaxHp;
	//	hpImage.fillAmount = hpRemain;
	//}
}