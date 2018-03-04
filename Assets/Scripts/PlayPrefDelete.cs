using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPrefDelete : MonoBehaviour {

	//Zum initialisieren
	void Start () {
        PlayerPrefs.DeleteAll();
    }

}