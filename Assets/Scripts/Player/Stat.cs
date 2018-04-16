using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

[System.Serializable]
public class Stat
{

    [SerializeField]
    private ObscuredInt baseValue;

    public int GetValue()
    {

        return baseValue;
    }

}