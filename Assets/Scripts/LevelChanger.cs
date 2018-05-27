using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {


    public Animator animator;
    private int levelToLoad;
	
	
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);

        //Beim ersten Start des Spiels wird der Player erst generiert und existiert noch nicht daher muss hier ein try-catch Block hin.
        try
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().IsInputEnabled = true;
        }   catch (NullReferenceException)
        {
            //Debug.Log("NullReferenceException");
            return;
        }
        GameObject.Find("Player").GetComponent<PlayerMovement>().isDeath = false;
    }

	
}
