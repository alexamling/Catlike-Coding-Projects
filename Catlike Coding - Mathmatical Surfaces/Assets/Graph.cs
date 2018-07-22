using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate Vector3 GraphFunction(float u, float v, float t);
public enum GraphFunctionName { Sine, Sine2D, Sine2D_Alt, MultiSine, Multi2DSine, Ripple, Cylinder, Cylinder_Alt, Sphere, Sphere_Alt, Torus, Torus_Alt }

public class Graph : MonoBehaviour {

    public Transform pointPrefab;

    [Range(10,100)]
    public int resolution = 10;
    public GraphFunctionName function;

    Transform[] points;
    static GraphFunction[] functions = {
        SineFunction, Sine2DFunction, Alt2DFunction, MultiSineFunction, Multi2DFunction, Ripple, Cylinder, Cylinder_Alt, Sphere, Sphere_Alt, Torus, Torus_Alt
    };

	void Start () {
        points = new Transform[resolution * resolution];

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;

        for (int i = 0; i < points.Length; i++){
            Transform point = Instantiate(pointPrefab);
            points[i] = point;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
	

	void Update () {
        float t = Time.time;
        GraphFunction f = functions[(int)function];
        float step = 2f / resolution;
        for (int i = 0, z = 0; z < resolution; z++)
        {
            float v = (z + .5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, t);
            }
        }
	}


    const float pi = Mathf.PI;

    static Vector3 SineFunction (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.z = v;
        return p;
    }

    static Vector3 MultiSineFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * u + t);
        p.y += Mathf.Sin(2f * pi * u + 2f * t * 2) / 2f;
        p.y *= 2f / 3f;
        p.z = v;
        return p;
    }

    static Vector3 Sine2DFunction (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + v + t));
        p.z = v;
        return p;
    }

    static Vector3 Alt2DFunction (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(pi * (v + t));
        p.y *= .5f;
        p.z = v;
        return p;
    }

    static Vector3 Multi2DFunction (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = 4.0f * Mathf.Sin(pi * (u + v + t * .5f));
        p.y += Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(pi * 2.0f * (v + 2.0f + t)) * .5f;
        p.y *= 1.0f / 5.5f;
        p.z = v;
        return p;
    }

    static Vector3 Ripple (float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        float d = Mathf.Sqrt(u * u + v * v);
        p.y = Mathf.Sin(pi * (4.0f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

    static Vector3 Cylinder (float u, float v, float t)
    {
        Vector3 p;
        float r = 1f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Cylinder_Alt(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * u + 2f * v + t)) * .2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Sphere(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(pi * .5f * v);
        p.x = r * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * .5f * v);
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Sphere_Alt(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * u + 2f * v + t)) * .2f;
        r += Mathf.Sin(pi * (4f * v + t)) * .1f;
        float s = r * Mathf.Cos(pi * .5f * v);
        p.x = s * Mathf.Sin(pi * u);
        p.y = r * Mathf.Sin(pi * .5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Torus(float u, float v, float t)
    {
        Vector3 p;
        float r1 = 1f;
        float r2 = .5f;
        float s = r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Torus_Alt(float u, float v, float t)
    {
        Vector3 p;
        float r1 = .65f + Mathf.Sin(pi * (8f * u + 2f * v + t)) * .1f;
        float r2 = .2f + Mathf.Sin(pi * (6f * u + 2f * v + t)) * .05f;
        float s = r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }
}
