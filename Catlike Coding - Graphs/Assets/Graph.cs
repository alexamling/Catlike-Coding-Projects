using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform pointPrefab;

	void Start () {
        for (int i = 0; i < 10; i++){
            Transform point = Instantiate(pointPrefab);
            point.localPosition = transform.right * ((i + .5f) / 5f - 1f); // center cubes and place between (-1,1)
            point.localScale = Vector3.one / 5f;
        }
    }
	

	void Update () {
		
	}
}
