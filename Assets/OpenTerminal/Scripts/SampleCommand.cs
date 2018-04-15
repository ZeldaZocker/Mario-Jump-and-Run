using UnityEngine;

public class SampleCommand
{
    [Command("debug", "Debugs a sample line in Unity Console")]
    public void SampleDebug()
    {
        Debug.Log("Ich bin ein Beispiel!");
    }
}
