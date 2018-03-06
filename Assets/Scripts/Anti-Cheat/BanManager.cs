using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanManager : MonoBehaviour {

	//Zum initialisieren
	void Start () {

        if (PlayerPrefs.GetInt("banned") != 1)
            PlayerPrefs.SetInt("banned", 0);

        if (PlayerPrefs.GetInt("banned") == 1)
            Application.Quit();
    }
    
}