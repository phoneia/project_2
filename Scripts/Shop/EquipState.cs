using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipState : Item
{

    public int ap;
    public int dp;

    public int DP
    {
        get { return dp; }
        set { dp = value; }
    }

    public int AP
    {
        get { return ap; }
        set { ap = value; }
    }
}
