using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheatResults : MonoBehaviour {




    public void Quit()
    {
        Application.Quit();
    }

    public void Ban()
    {
        PlayerPrefs.SetInt("banned", 1);
    }

}