using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float GraphFunction(float x, float z, float t);
public enum GraphFunctionName { Sine, Sine2D, Sine2D_Alt, MultiSine, Multi2DSine, Ripple }

public class Graph : MonoBehaviour {

    public Transform pointPrefab;

    [Range(10,100)]
    public int resolution = 10;
    public GraphFunctionName function;

    Transform[] points;
    static GraphFunction[] functions = {
        SineFunction, Sine2DFunction, Alt2DFunction, MultiSineFunction, Multi2DFunction, Ripple
    };

	void Start () {
        points = new Transform[resolution * resolution];

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;

        for (int i = 0, z = 0; z < resolution; z++){
            position.z = (z + .5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                Transform point = Instantiate(pointPrefab);
                points[i] = point;

                position.x = (x + .5f) * step - 1f;
                point.localPosition = position;
                point.localScale = scale;
                point.SetParent(transform);

            }
        }
    }
	

	void Update () {
        float t = Time.time;
        GraphFunction f = functions[(int)function];
        for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                Vector3 position = point.localPosition;
                position.y = f(position.x, position.z, t);
                point.localPosition = position;
            }
		
	}


    const float pi = Mathf.PI;

    static float SineFunction (float x, float z, float t)
    {
        return Mathf.Sin(pi * x + t * 2);
    }

    static float MultiSineFunction(float x, float z, float t)
    {
        float y = Mathf.Sin(pi * x + t);
        y += Mathf.Sin(2f * pi * x + 2f * t * 2) / 2f;
        y *= 2f / 3f;
        return y;
    }

    static float Sine2DFunction (float x, float z, float t)
    {
        return Mathf.Sin(pi * (x + z + t));
    }

    static float Alt2DFunction (float x, float z, float t)
    {
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(pi * (z + t));
        y *= .5f;
        return y;
    }

    static float Multi2DFunction (float x, float z, float t)
    {
        float y = 4.0f * Mathf.Sin(pi * (x + z + t * .5f));
        y += Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(pi * 2.0f * (z + 2.0f + t)) * .5f;
        y *= 1.0f / 5.5f;
        return y;
    }

    static float Ripple (float x, float z, float t)
    {
        float d = Mathf.Sqrt(x * x + z * z);
        float y = Mathf.Sin(pi * (4.0f * d - t));
        y /= 1f + 10f * d;
        return y;
    }
}
