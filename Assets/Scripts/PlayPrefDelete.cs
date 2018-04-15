using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class PlayPrefDelete : MonoBehaviour
{

    //Zum initialisieren
    void LateUpdate()
    {
        ObscuredPrefs.DeleteAll();
        PlayerPrefs.DeleteAll();
    }

}