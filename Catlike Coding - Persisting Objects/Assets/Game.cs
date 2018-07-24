using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Transform prefab;

    public KeyCode createKey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;
    
	void Update () {
        if (Input.GetKeyDown(createKey))
        {
            CreateObject();
        }
	}

    void CreateObject()
    {
        Transform t = Instantiate(prefab);
        t.localPosition = Random.insideUnitSphere * 5f;
        t.rotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(.1f, 1f);
    }
}
