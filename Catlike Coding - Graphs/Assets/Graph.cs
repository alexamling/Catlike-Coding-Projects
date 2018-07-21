using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform pointPrefab;

	void Start () {
        Transform point = Instantiate(pointPrefab);
        point.localPosition = transform.right;
        
        point = Instantiate(pointPrefab);
        point.localPosition = transform.right * 2f;
    }
	

	void Update () {
		
	}
}
