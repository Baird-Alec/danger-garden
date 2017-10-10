using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    GameObject parent;
    public GameObject[] attackerPrefab;
	
	// Update is called once per frame
	void Update () {
	foreach (GameObject enemy in attackerPrefab)
        {
            if (isTimeToSpawn (enemy))
            {
                Spawn(enemy);
            }
        }
	}

    bool isTimeToSpawn (GameObject enemyAttacker)
    {
        Attacker attacker = enemyAttacker.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.spawnEverySeconds;
        float spawnPerSec = 1 / meanSpawnDelay;

        if(Time.deltaTime > spawnPerSec)
        {
            Debug.LogWarning("Frame rate is capping spawn rate");
        }

        float limit = Time.deltaTime * spawnPerSec / 5;
        return (Random.value < limit);
    }

    void Spawn (GameObject gameObject)
    {
        GameObject myAttacker = Instantiate(gameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
