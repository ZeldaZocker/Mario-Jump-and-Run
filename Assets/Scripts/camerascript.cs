using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat;

public class camerascript : MonoBehaviour {

    public List<Transform> targets;
    public ObscuredVector3 offset = new Vector3(2, 2, -1);

	void LateUpdate () {

        if (targets.Count == 0)
        {
            return;
        }

        ObscuredVector3 centerPoint = GetCenterPoint();

        ObscuredVector3 newPosition = centerPoint + offset;

        transform.position = newPosition;
        

	}

    private void Update()
    {
        targets[0] = GameObject.Find("Player").GetComponent<Transform>();
    }

    ObscuredVector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }



        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;

    }



}
