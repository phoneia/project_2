using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    [SerializeField]
    private CharacterLevelUpState levelUp;

    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private GameObject levelupPoint;

    public enum CharState
    {
        Idle, Move, Attack1,

        Attack2, Attack3, Attack4, Death,
    }

    void Start()
    {
        levelUp = GetComponent<CharacterLevelUpState>();
    }
    void Update()
    {
        
        reqExp = levelUp.LevReq(level);

        if (currentExp >= levelUp.LevReq(level))
        {
            currentExp = 0;
            level++;
            Instantiate(effect, levelupPoint.transform.position, Quaternion.identity);
            currentHp = maxHp + levelUp.LevHp(level);
            currentMp = maxMp + levelUp.LevMp(level);
        }

    }

    [SerializeField]
    private int characterNum;

    public int CharacterNum
    {
        get { return characterNum; }
        set { characterNum = value; }
    }

    [SerializeField]
    [Range(1, 30)]
    private int level =1;

    [SerializeField]
    private int currentHp;

    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int currentMp;

    [SerializeField]
    private int maxMp;

    [SerializeField]
    private int currentGold;

    [SerializeField]
    private int currentExp;

    [SerializeField]
    private int getGold;

    [SerializeField]
    private int getExp;

    [SerializeField]
    private int reqExp;

    public float regenHp;

    public float regenMp;

    public float RegemMp
    {
        get { return regenMp; }
        set { regenMp = value; }
    }

    public float RegemHp
    {
        get { return regenHp; }
        set { regenHp = value; }
    }


    // 공격을 하고 있는지 확인하기위한 것
    [SerializeField]
    private bool isAttack = false;

    [SerializeField]
    private int att;

    [SerializeField]
    private int def;

    [SerializeField]
    private float speed = 3.0f;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Def
    {
        get { return def + levelUp.LevDef(level); }
        set { def = value; }
    }

    public int Att
    {
        get { return att + levelUp.LevAtt(level); }
        set { att = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public bool IsAttack
    {
        get { return isAttack; }
        set { isAttack = value; }
    }

    public CharState charstate;

    public int MaxMp
    {
        get { return maxMp + levelUp.LevMp(level); }
        set { maxMp = value; }
    }

    public int CurrentMp
    {
        get { return currentMp; }
        set { currentMp = value; }
    }

    public int MaxHp
    {
        get { return maxHp + levelUp.LevHp(level); }
        set { maxHp = value; }
    }

    public int CurrentHp
    {
        get { return currentHp; }
        set { currentHp = value; }
    }

    public int CurrentGold
    {
        get { return currentGold; }
        set { currentGold = value; }
    }

    public int GetGold
    {
        get { return getGold; }
        set { getGold = value; }
    }

    public int CurrentExp
    {
        get { return currentExp; }
        set { currentExp = value; }
    }

    public int GetExp
    {
        get { return getExp; }
        set { getExp = value; }
    }

    public int ReqExp
    {
        get { return reqExp + levelUp.LevReq(level); }
        set { reqExp = value; }
    }

}