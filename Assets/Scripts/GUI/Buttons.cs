using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class Buttons : MonoBehaviour
{

    public void Play()
    {
        if (ObscuredPrefs.GetInt("banned") == 1)
                Application.Quit();
        else
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Quit()
    {
        Application.Quit();
    }

}