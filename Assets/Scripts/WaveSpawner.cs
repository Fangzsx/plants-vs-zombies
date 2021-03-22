using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    private Transform[] spawnPoints;
    private Transform[] pursuePoints;
    private Transform randomPoint;
    private float timeBetweenSpawn = 5f;
    public static Transform laneToPush;
    
    public GameObject zombiePrefab;
    public float yOffset = 0.6f;
    
    public float countdown = 0f;

    private void Start()
    {
        spawnPoints = SpawnPoint.points;
        pursuePoints = PursuePoint.points;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(RandomSpawn());
            countdown = timeBetweenSpawn;
        }
        countdown -= Time.deltaTime;
    }


    IEnumerator RandomSpawn()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        randomPoint = spawnPoints[randomIndex];
        laneToPush = pursuePoints[randomIndex];
        SpawnZombie();
        yield return new WaitForSeconds(0.5f);

    }

    void SpawnZombie()
    {

        Vector3 position = new Vector3(randomPoint.transform.position.x, randomPoint.transform.position.y + yOffset, randomPoint.transform.position.z);

        Debug.Log("Zombie Spawned!");
        Instantiate(zombiePrefab, position, randomPoint.rotation);
    }
}
