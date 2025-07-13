using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    private int wave, difficulty, score;
    bool waveSpawned, game;
    public GameObject shootingWave, suicideWave, boss, startButton;
    public PlayerScript playerScript;
    public GameObject[] enemies;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        game = false;
    }
    void Update()
    {
        if (game == true)
        {
            if (waveSpawned == false)
            {
                if (wave == 0)
                {
                    //spawn shooting
                    var spawnedWave = Instantiate(shootingWave, new Vector3(1, 2.5f, 0), transform.rotation);
                    spawnedWave.GetComponent<StandingWaveScrtipt>().SetDifficulty(difficulty);
                    waveSpawned = true;
                }
                else if (wave == 1)
                {
                    //spawn sucide
                    var spawnedWave = Instantiate(suicideWave, transform.position, transform.rotation);
                    spawnedWave.GetComponent<SuicideWaveScript>().SetDifficulty(difficulty);
                    waveSpawned = true;
                }
                else if (wave == 2)
                {
                    //spawn schooting
                    var spawnedWave = Instantiate(shootingWave, new Vector3(1, 2.5f, 0), transform.rotation);
                    spawnedWave.GetComponent<StandingWaveScrtipt>().SetDifficulty(difficulty);
                    waveSpawned = true;
                }
                else
                {
                    //spawn boss
                    var spawnedWave = Instantiate(boss, new Vector3(0f, 7f, 0f), transform.rotation);
                    spawnedWave.GetComponent<BossScript>().SetDifficulty(difficulty);
                    waveSpawned = true;
                }
            }
        }
        scoreText.text = score.ToString();
    }
    public void AddScore(int points)
    {
        score += points;
    }
    public void EndWave()
    {
        if (wave < 3)
            wave++;
        else
        {
            wave = 0;
            if (difficulty < 10)
                difficulty++;
        }
        waveSpawned = false;
    } 

    public void StartGame()
    {
        wave = 0;
        difficulty = 0;
        score = 0;
        game = true;
        playerScript.SetLives(3);
        playerScript.SetWeapon(1);
        waveSpawned = false;
        startButton.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        game = false;
        if (GameObject.FindGameObjectsWithTag("Enemy") != null)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies){
                enemy.transform.DOKill(enemy.transform);
                Destroy(enemy);
            }
        }
        startButton.SetActive(true);
    }
    
}
