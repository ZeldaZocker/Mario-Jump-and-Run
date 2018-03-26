using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class MusicScript : MonoBehaviour
{
    public AudioSource m_MyAudioSource;

    //Play the music
    public bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    public bool actualSetting;





    void Start()
    {

        m_MyAudioSource = GetComponent<AudioSource>();

        //Wenn die Musik beim letzten Speichern aus war:
        if (ObscuredPrefs.GetInt("musicEnabled") == 0)
        {
            GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_Play = false;
            if (GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_MyAudioSource == null)
                GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_MyAudioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
            if (m_MyAudioSource.isPlaying)
                GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_MyAudioSource.Stop();
            Debug.Log("Loaded: False!");
        }

        //Wenn die Musik beim letzten Speichern an war:
        else if (ObscuredPrefs.GetInt("musicEnabled") == 1)
        {
            GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_Play = true;
            if (GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_MyAudioSource == null)
                GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_MyAudioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
            if (!m_MyAudioSource.isPlaying)
                GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_MyAudioSource.Play();
            Debug.Log("Loaded: True!");
        }
    }


    void Update()
    {
        //Damit es nicht dauernd speichert überprüft es hier ob sich der bool actualSettings von m_Play unterscheidet.
        if (actualSetting != GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_Play)
        {

            //Wenn er sich unterscheidet und m_Play false ist wird false gespeichert.
            if (!GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_Play)
            {
                ObscuredPrefs.SetInt("musicEnabled", 0);
                Debug.Log("Saved: False!");
            }
            //Wenn er sich unterscheidet und m_Play true ist wird true gespeichert.
            else
            {
                ObscuredPrefs.SetInt("musicEnabled", 1);
                Debug.Log("Saved: True!");
            }
            //Und dann actualSettings wieder an m_Play angepasst.
            actualSetting = GameObject.Find("MusicPlayer").GetComponent<MusicScript>().m_Play;
        }

        //Wenn m_Play true ist die Musik jedoch nicht gespielt wird....
        if (m_Play == true && !m_MyAudioSource.isPlaying)
        {
            //Wird die Musik gestartet.
            m_MyAudioSource.Play();
        }
        //Wenn m_Play false ist die Musik jedoch  gespielt wird....
        if (m_Play == false && m_MyAudioSource.isPlaying)
        {
            //Wird die Musik gestoppt.
            m_MyAudioSource.Stop();
        }
    }




    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        m_Play = GUI.Toggle(new Rect(12, 40, 100, 25), m_Play, "Play Music");
    }
}