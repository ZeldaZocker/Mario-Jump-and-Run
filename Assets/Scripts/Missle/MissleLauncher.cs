using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MissleLauncher : MonoBehaviour {

    public GameObject missle;
    public Transform bulletSpawn;



	//Zum initialisieren
	void Start () {
        StartCoroutine(MissleLaunching());
    }

    

    IEnumerator MissleLaunching()
    {
        while (true)
        {
            Instantiate(missle, bulletSpawn.position, bulletSpawn.rotation);
            GameObject.Find("MissleCounter").GetComponent<MissleCounter>().missles++;
            yield return new WaitForSeconds(5);
        }
        
    }

    

}