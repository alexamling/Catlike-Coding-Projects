using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform pointPrefab;

	void Start () {
        Vector3 scale = Vector3.one / 5f;
        Vector3 position;
        position.z = 0f;

        for (int i = 0; i < 10; i++){
            Transform point = Instantiate(pointPrefab);
            position.x = (i + .5f) / 5f - 1f; // center cubes and place between (-1,1)
            position.y = position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    }
	

	void Update () {
		
	}
}
