using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Transform pointPrefab;
    [Range(10,100)]
    public int resolution = 10;

    Transform[] points;

	void Start () {
        points = new Transform[resolution];

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;

        for (int i = 0; i < resolution; i++){
            Transform point = Instantiate(pointPrefab);
            points[i] = point;

            position.x = (i + .5f) * step - 1f; // center cubes and place between (-1,1)

            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform);
        }
    }
	

	void Update () {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * position.x + Time.time);
            point.localPosition = position;
        }
		
	}
}
