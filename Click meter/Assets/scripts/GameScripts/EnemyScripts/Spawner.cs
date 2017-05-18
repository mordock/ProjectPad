using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;

    public Vector3 spawnPosition;
    private int yMin, yMax, xMin, xMax;
    private float spawnInterval;
    private float timer = 0f;
    private float spawnRateTimer = 0f;
    private float increaseSpawnRate;

    private void Start () {
        spawnInterval = 1;
        increaseSpawnRate = 10;
    }

    private void createEnemy()
    {
        yMin = -10;
        yMax = 20;
        xMin = -10;
        xMax = 20;

        //This refers to the spawn on the positive side of the screen.
        
            int spawnPointX = Random.Range(xMin, xMax);
            int spawnPointY = Random.Range(yMin, yMax);

            if (spawnPointX > -10 || spawnPointX < 10 && spawnPointY > -5 || spawnPointY < 5)
        {
            spawnPointX *= 3;
            spawnPointY *= 3;
        }
            this.spawnPosition = new Vector3(spawnPointX, spawnPointY, 10);
            this.transform.position = spawnPosition;
        
        //Always instatiate objects, things wont work otherwise in Unity,
        GameObject Enemy = Instantiate(this.enemy, this.spawnPosition, Quaternion.identity) as GameObject;
    }

    private void Update()
    {
        if (timer > spawnInterval)
        {
            createEnemy();
            timer = 0f;
        }
        timer += Time.deltaTime;

        if(spawnRateTimer > increaseSpawnRate)
        {
            spawnInterval -= 0.1f;
            spawnRateTimer = 0f;
        }
        spawnRateTimer += Time.deltaTime;
    }
}
