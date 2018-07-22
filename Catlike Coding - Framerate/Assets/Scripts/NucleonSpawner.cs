using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

    public float timeBetweenSpawns;
    public float spawnDistance;

    float timeSinceLastSpawn;

    public Nucleon[] nucleonPrefabs;

	// Use this for initialization
	void Awake() {
		
	}


    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }

    void SpawnNucleon()
    {
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab, gameObject.transform);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}
