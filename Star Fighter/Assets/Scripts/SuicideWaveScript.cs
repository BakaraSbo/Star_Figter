using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideWaveScript : MonoBehaviour
{
    public GameObject Spawner;
    private float waveTime;
    private int difficulty;
    GameManagerScript managerScript;
    public float[] maxCooldownScaling, shipSpeedScaling;
    private void Start()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        waveTime = 15f;
        
        
    }
    private void Update()
    {
        if (waveTime <= 0)
            EndWave();
        else
            waveTime -= Time.deltaTime;
    }
    void EndWave()
    {
        managerScript.EndWave();
        Destroy(gameObject);
    }
    public void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
        SpawnSpawners();
    }

    public void SpawnSpawners()
    {
        int x = 0;
        for (int i = 1; i <= 2; i++)
        {
            var spawner = Instantiate(Spawner, transform);
            SpawnerScript spawnewScript = spawner.GetComponent<SpawnerScript>();
            spawnewScript.SetParamiters(maxCooldownScaling[difficulty], x, x + 3, 13f, shipSpeedScaling[difficulty]);
            x -= 3;
        }
    }
}
