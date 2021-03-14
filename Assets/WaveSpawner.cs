using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    private Transform[] points;
    private Transform randomPoint;
    private float timeBetweenSpawn = 3f;
    public float countdown = 0f;
    public GameObject zombiePrefab;

    private void Start()
    {
        points = SpawnPoint.points;
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
        int randomIndex = Random.Range(0, points.Length);
        randomPoint = points[randomIndex];
        Debug.Log("Random Spawn Point" + randomPoint);
        SpawnZombie();
        yield return new WaitForSeconds(0.5f);

    }

    void SpawnZombie()
    {
        Debug.Log("Zombie Spawned!");
        Instantiate(zombiePrefab, randomPoint.position, randomPoint.rotation);
    }
}
