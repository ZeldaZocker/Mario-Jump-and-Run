using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class MissleCounter : MonoBehaviour
{



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
            UpdateRecord(missles);
        }
    }

    public void UpdateRecord(int missles)
    {
        record = missles;
        ObscuredPrefs.SetInt("record", record);
    }

    void OnGUI()
    {
       GUI.Box(new Rect(1670, 1000, 100, 25), "Missles: " + missles.ToString());
       GUI.Box(new Rect(1780, 1000, 100, 25), "Record: " + record.ToString());
    }

    public void Reset()
    {
        missles = 0;
    }
}
