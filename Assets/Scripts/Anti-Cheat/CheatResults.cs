using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class CheatResults : MonoBehaviour {




    public void Quit()
    {
        Application.Quit();
    }

    public void Ban()
    {
        ObscuredPrefs.SetInt("banned", 1);
    }

}