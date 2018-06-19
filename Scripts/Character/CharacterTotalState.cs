using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTotalState : MonoBehaviour
{
    [SerializeField] private CharacterStates state;
    [SerializeField] private InventorySlot[] items;
    [SerializeField] private SkillManager skill;

    public Inventory inven;

    private int ta;
    private int td;

    public int Td
    {
        get { return td; }
        set { td = value; }
    }
	
    public int Ta
    {
        get { return ta; }
        set { ta = value; }
    }

	void Awake()
	{
		state = GetComponent<CharacterStates>();
		inven = GameObject.Find("UI/InventoryBG").GetComponent<Inventory>();
        skill = GameObject.Find("UI/CharacterStateInfo/Skll").GetComponent<SkillManager>();
    }

	void Update()
    {
        // inven.CulAtt();
        // inven.CulDef();

        ta = state.Att + inven.CulAtt() + skill.CulSkill();
        td = state.Def + inven.CulDef() + skill.CulSkill();
        
    }

}
