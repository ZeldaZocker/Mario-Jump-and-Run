using UnityEngine;
using UnityEditor;

public class Hider : EditorWindow
{

    [MenuItem("GameObject_Hider&Destroyer/Start")]
    public static void Create()
    {
        GetWindow<Hider>();
    }

    void OnGUI()
    {

        if (GUILayout.Button("Create hidden GO"))
        {
            GameObject h = new GameObject("Temp-SceneCreatedMarker");
            h.hideFlags = HideFlags.HideInHierarchy;
        }
        if (GUILayout.Button("Select hidden GO"))
        {
            Selection.activeGameObject = GameObject.Find("Temp-SceneCreatedMarker");
        }

        if (GUILayout.Button("Destory Selected Object"))
        {
            DestroyImmediate(Selection.activeObject);
        }
    }
}
