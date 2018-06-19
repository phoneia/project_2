using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public Image image;

    private SkillData skillData;

    public SkillData SkillData
    {
        get { return skillData; }
        set
        {
            skillData = value;

            if (skillData == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = skillData.icon;
                image.enabled = true;
            }

        }
    }


    private void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }
}
