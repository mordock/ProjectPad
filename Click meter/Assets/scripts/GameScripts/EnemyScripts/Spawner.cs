using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;

    public Vector3 spawnPosition;
    private int yMin, yMax, xMin, xMax;
    private float spawnInterval;
    private float timer = 0f;
    private float spawnRateTimer = 0f;
    private float increaseSpawnRate;

    private void Start()
    {
        spawnInterval = 1;
        increaseSpawnRate = 10;

        //This is to set the different spawn times for the different ant types. enemy has no seperate spawn time because it's the default.
        if (gameObject.tag == "SoldierAnt")
        {
            spawnInterval = 10;
            increaseSpawnRate = 50;
        }
        if (gameObject.tag == "BulletAnt")
        {
            spawnInterval = 20;
            increaseSpawnRate = 70;
        }
    }

    private void createEnemy()
    {
        yMin = -10;
        yMax = 20;
        xMin = -10;
        xMax = 20;

        int spawnPointX = Random.Range(xMin, xMax);
        int spawnPointY = Random.Range(yMin, yMax);

        //Because the base is the 0,0 value within this game to ensure enemies only spawn offscreen, this littel code snippit is used.
        if (spawnPointX > -10 || spawnPointX < 10 && spawnPointY > -5 || spawnPointY < 5)
        {
            spawnPointX *= 3;
            spawnPointY *= 3;
        }
        this.spawnPosition = new Vector3(spawnPointX, spawnPointY, 10);
        this.transform.position = spawnPosition;

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

        if (spawnRateTimer > increaseSpawnRate)
        {
            spawnInterval -= 0.1f;
            spawnRateTimer = 0f;
        }
        spawnRateTimer += Time.deltaTime;
    }
}
