using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUiBar : MonoBehaviour
{
	[SerializeField]
	private Image hpImage;

	[SerializeField]
	private Image mpImage;

	[SerializeField]
	private Image expImage;

	[SerializeField]
	private Text expText;

	[SerializeField]
	private Text gold;

	[SerializeField]
	private CharacterStates state;

	[SerializeField]
	private Text hpText;

	[SerializeField]
	private Text mpText;

    [SerializeField]
    private CharacterTotalState tState;

    [SerializeField]
    private Text attackPower;

    [SerializeField]
    private Text defencePower;

    [SerializeField]
    private Text level;

    private int gol;
    private int exp;

    void Start()
	{
		state = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStates>();
        tState = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterTotalState>();
        attackPower = GameObject.Find("UI/CharacterStateInfo/StateInfo 1/Text (1)").GetComponent<Text>();
        defencePower = GameObject.Find("UI/CharacterStateInfo/StateInfo 1/Text (2)").GetComponent<Text>();
    }

	void Update()
	{
		transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

		hpText.text = state.CurrentHp + " / " + state.MaxHp;
        mpText.text = state.CurrentMp + " / " + state.MaxMp;
        expText.text = state.CurrentExp + " %";
		gold.text = state.CurrentGold + "";
        level.text = "LV : " + state.Level;

        attackPower.text = tState.Ta.ToString();
        defencePower.text = tState.Td.ToString();

        HpDown();
        MpDown();
        GetExp(exp);
        GetGold(gol);
    }
	
	public void HpDown()
	{
		//state.CurrentHp -= damage;

		float hpRemain = (float)state.CurrentHp / state.MaxHp;
		hpImage.fillAmount = hpRemain;

		//return state.CurrentHp;
	}

	public void SetHp(int hp)
	{
		state.CurrentHp = hp;

		float hpRemain = (float)state.CurrentHp / state.MaxHp;
		hpImage.fillAmount = hpRemain;
	}

	public void MpDown()
	{
		//state.CurrentMp -= casting;

		float mpRemain = (float)state.CurrentMp / state.MaxMp;
		mpImage.fillAmount = mpRemain;

		//return state.CurrentMp;
	}

	public void SetMp(int mp)
	{
		state.CurrentMp = mp;

		float mpRemain = (float)state.CurrentMp / state.MaxMp;
		mpImage.fillAmount = mpRemain;
	}

	public void SetExp(int exp)
	{
		state.CurrentExp = exp;

		float expRemain = (float)state.CurrentExp / state.GetExp;
		expImage.fillAmount = expRemain;
	}

	public void GetExp(int getExp)
	{
		state.CurrentExp += getExp;

		float expRemain = (float)state.CurrentExp /state.ReqExp;
		expImage.fillAmount = expRemain;
	}

	public void SetGold(int gold)
	{
		state.CurrentGold = gold;
	}

	public void GetGold(int gold)
	{
		state.CurrentGold += gold;
	}
}