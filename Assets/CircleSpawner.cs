using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject changerPrefab;
    public GameObject coinPrefab;
    public float respawnTime = 1f;
    private float currentY = 3.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int prevScore = 0;

    // Update is called once per frame
    void Update()
    {
        Player ply = FindObjectOfType<Player>();
        if (prevScore != ply.Score)
        {
            prevScore = ply.Score;
            SpawnCircle();
        }
    }

    public void SpawnCircle()
    {

        GameObject changer = Instantiate(changerPrefab);
        GameObject circle = Instantiate(circlePrefab);
        GameObject coin = Instantiate(coinPrefab);

        currentY += 4.5f;

        changer.transform.position = new Vector3(changer.transform.position.x, currentY, changer.transform.position.z);

        currentY += 3.9f;

        circle.transform.position = new Vector3(circle.transform.position.x, currentY, circle.transform.position.z);

        coin.transform.position = new Vector3(coin.transform.position.x, currentY, coin.transform.position.z);


    }
}
