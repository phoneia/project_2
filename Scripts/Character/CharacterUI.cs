using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
	[SerializeField]
	private Image hpImage;

	[SerializeField]
	private Image mpImage;

	[SerializeField]
	private CharacterStates state;

    [SerializeField]
    private Transform uiPivot;

    [SerializeField]
    private Text hpText;

    [SerializeField]
    private Text mpText;

	void Start()
	{
		state = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStates>();
		uiPivot = GameObject.Find("UiPivot").transform;
	}

    void Update()
    {
        transform.position = uiPivot.transform.position;
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        hpText.text = state.CurrentHp + " / " + state.MaxHp;
        mpText.text = state.CurrentMp + " / " + state.MaxMp;

        float hpRemain = (float)state.CurrentHp / state.MaxHp;
        hpImage.fillAmount = hpRemain;

        float mpRemain = (float)state.CurrentMp / state.MaxMp;
        mpImage.fillAmount = mpRemain;
    }

    //public int HpDown(int damage)
	//{
	//	state.CurrentHp -= damage ;
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
    //
	//public int MpDown(int casting)
	//{
	//	state.CurrentMp -= casting;
    //
	//	float mpRemain = (float)state.CurrentMp / state.MaxMp;
	//	mpImage.fillAmount = mpRemain;
    //
	//	return state.CurrentMp;
	//}
    //
	//public void SetMp(int mp)
	//{
	//	state.CurrentMp = mp;
    //
	//	float mpRemain = (float)state.CurrentMp / state.MaxMp;
	//	mpImage.fillAmount = mpRemain;
	//}
}