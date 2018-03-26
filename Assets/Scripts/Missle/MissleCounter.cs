using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class MissleCounter : MonoBehaviour {



    public ObscuredInt missles = 0;
    public ObscuredInt record = 0;

    private void Start()
    {
        record = ObscuredPrefs.GetInt("record");
    }

    void Update()
    {
        if (missles < 0)
        {
            missles = 0;
        }

        if (record < missles)
        {
            record = missles;
            ObscuredPrefs.SetInt("record", record);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 25), "Missles: " + missles.ToString());
        GUI.Box(new Rect(120, 10, 100, 25), "Record: " + record.ToString());
    }


}