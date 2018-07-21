using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform pointPrefab;
    [Range(10,100)]
    public int resolution = 10;

	void Start () {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.z = 0f;

        for (int i = 0; i < resolution; i++){
            Transform point = Instantiate(pointPrefab);
            position.x = (i + .5f) * step - 1f; // center cubes and place between (-1,1)
            position.y = position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
    }
	

	void Update () {
		
	}
}
