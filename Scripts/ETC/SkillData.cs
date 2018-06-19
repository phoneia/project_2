using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillData : ScriptableObject
{
    public int skillNo;

    public string skillName;
    public Sprite icon;

    public int mp;
    public int damage;
    public float delay;
    public bool isUseable;
    public bool isDamage = false;
	
}
