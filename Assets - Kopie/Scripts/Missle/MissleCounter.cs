using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleCounter : MonoBehaviour {



    public int missles = 0;
    public int record = 0;


    void Update()
    {
        if (missles < 0)
        {
            missles = 0;
        }

        if (record < missles)
        {
            record = missles;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 25), "Missles: " + missles.ToString());
        GUI.Box(new Rect(120, 10, 100, 25), "Record: " + record.ToString());
    }


}