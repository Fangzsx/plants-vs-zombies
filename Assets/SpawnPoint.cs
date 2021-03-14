using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Transform[] points;
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
        RandomizeSpawnPoint();
    }

    void RandomizeSpawnPoint()
    {
        int randomIndex = Random.Range(0, points.Length);
        Debug.Log(points[randomIndex]);

    }
}
