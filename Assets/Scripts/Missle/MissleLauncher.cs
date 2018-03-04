using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour {

    public GameObject missle;
    public Transform bulletSpawn;
    public int missles = 0;



	//Zum initialisieren
	void Start () {
        StartCoroutine(MissleLaunching());
    }

    void Update()
    {
        if (missles < 0)
        {
            missles = 0;
        }
    }

    IEnumerator MissleLaunching()
    {
        while (true)
        {
            Instantiate(missle, bulletSpawn.position, bulletSpawn.rotation);
            missles++;
            yield return new WaitForSeconds(5);
        }
        
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 25), "Missles: " + missles.ToString());
    }

}