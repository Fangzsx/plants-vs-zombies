using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Transform[] points;
    public float timeBetweenWave = 5f;
    public float countdown = 0f;
    
    void Awake()
    {
        points = new Transform[transform.childCount];

        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }


    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(RandomizeSpawnPoint());
            countdown = timeBetweenWave;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator RandomizeSpawnPoint()
    {
        int randomIndex = Random.Range(0, points.Length);
  
        Debug.Log(points[randomIndex]);
        yield return new WaitForSeconds(0.5f);

    }
}
