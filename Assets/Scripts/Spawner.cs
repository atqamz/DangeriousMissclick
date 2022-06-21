using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
  public string waveName;
  public GameObject[] groundEnemies;
  public GameObject[] airEnemies;
  public GameObject bossEnemy;
  public int count;
  public float rate;
}

public class Spawner : MonoBehaviour
{
  [SerializeField] Wave[] spawnerWaves;
  [SerializeField] Transform[] spawnGroundPoint;
  [SerializeField] Transform[] spawnAirPoint;

  GameObject abilityHolder;

  SceneController sceneController;

  Wave currentWave;
  int curWaveIndex;
  bool canSpawn = true;
  float nextSpawnTime;

  void Awake()
  {
    sceneController = FindObjectOfType<SceneController>();
    abilityHolder = FindObjectOfType<AbilityHolder>().gameObject;
  }

  void FixedUpdate()
  {
    currentWave = spawnerWaves[curWaveIndex];
    SpawnWave();

    GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    GameObject[] totalEnemyBoss = GameObject.FindGameObjectsWithTag("EnemyBoss");

    if (totalEnemies.Length == 0 && totalEnemyBoss.Length == 0 && !canSpawn && curWaveIndex + 1 != spawnerWaves.Length)
    {
      SpawnNextWave();
    }
    else if (totalEnemies.Length == 0 && totalEnemyBoss.Length == 0 && !canSpawn && curWaveIndex + 1 == spawnerWaves.Length)
    {
      sceneController.LoadGameWin();
    }
  }

  void SpawnWave()
  {
    if (canSpawn && nextSpawnTime < Time.time)
    {
      int random = Random.Range(0, 2);

      if (random == 0)
      {
        SpawnGroundEnemies();
      }
      else
      {
        SpawnAirEnemies();
      }

      if (currentWave.count == 1)
      {
        SpawnWaveBoss();
      }

      if (currentWave.count == 0)
      {
        canSpawn = false;
        abilityHolder.GetComponent<AbilityHolder>().enabled = true;
      }
    }
  }

  void SpawnGroundEnemies()
  {
    int randomEnemy = Random.Range(0, currentWave.groundEnemies.Length);
    GameObject enemy = currentWave.groundEnemies[randomEnemy];
    Transform randomPoint = spawnGroundPoint[Random.Range(0, spawnGroundPoint.Length)];

    Instantiate(enemy, randomPoint.position, Quaternion.identity);
    currentWave.count--;
    nextSpawnTime = Time.time + currentWave.rate;
  }

  void SpawnAirEnemies()
  {
    int randomEnemy = Random.Range(0, currentWave.airEnemies.Length);
    GameObject enemy = currentWave.airEnemies[randomEnemy];
    Transform randomPoint = spawnAirPoint[Random.Range(0, spawnAirPoint.Length)];

    Instantiate(enemy, randomPoint.position, Quaternion.identity);
    currentWave.count--;
    nextSpawnTime = Time.time + currentWave.rate;
  }

  void SpawnWaveBoss()
  {
    GameObject enemy = currentWave.bossEnemy;
    Transform randomPoint = spawnAirPoint[Random.Range(0, spawnAirPoint.Length)];

    Instantiate(enemy, randomPoint.position, Quaternion.identity);
    currentWave.count--;
    nextSpawnTime = Time.time + currentWave.rate;
  }

  void SpawnNextWave()
  {
    canSpawn = true;
    curWaveIndex++;
  }
}
