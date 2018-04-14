using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class BanManager : MonoBehaviour {

	//Zum initialisieren
	void Start () {

        if (ObscuredPrefs.GetInt("banned") != 1)
            ObscuredPrefs.SetInt("banned", 0);

        if (ObscuredPrefs.GetInt("banned") == 1)
            Application.Quit();
    }
    
}