using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float timeToHardest = 120f;
    public float spawnTime;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public int maxMonsters = 30;
    public static int numMonsters;
    public Transform[] spawnPoints;


    void Start ()
    {
        spawnTime = maxSpawnTime;
        Invoke ("Spawn", spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        if (numMonsters < maxMonsters)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            numMonsters++;
        }

        spawnTime = (timeToHardest - Time.fixedTime) / timeToHardest * (maxSpawnTime - minSpawnTime) + minSpawnTime;
        spawnTime = Mathf.Max(minSpawnTime, spawnTime);
        Invoke("Spawn", spawnTime);
    }

    public static void EnemyDied()
    {
        numMonsters--;
    }
}
