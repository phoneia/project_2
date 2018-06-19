using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionState : MonoBehaviour
{
	public enum MinState { Idle, Move, Attack, Death }

	[SerializeField]
	private int currentHp;

	[SerializeField]
	private int maxHp;

	[SerializeField]
	private int currentMp;

	[SerializeField]
	private int maxMp;

	[SerializeField]
	private int gold;

	[SerializeField]
	private int exp;
	
	public MinState minstate;

    [SerializeField]
    private int att;

    [SerializeField]
    private int def;

    public int Def
    {
        get { return def; }
        set { def = value; }
    }

    public int Att
    {
        get { return att; }
        set { att = value; }
    }

    public int MaxMp
	{
		get { return maxMp; }
		set { maxMp = value; }
	}

	public int CurrentMp
	{
		get { return currentMp; }
		set { currentMp = value; }
	}

	public int MaxHp
	{
		get { return maxHp; }
		set { maxHp = value; }
	}

	public int CurrentHp
	{
		get { return currentHp; }
		set { currentHp = value; }
	}

	public int Gold
	{
		get { return gold; }
		set { gold = value; }
	}

	public int Exp
	{
		get { return exp; }
		set { exp = value; }
	}
}