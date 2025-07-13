using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StandingWaveScrtipt : MonoBehaviour
{
    public GameObject[] ships;
    GameManagerScript gameManagerScript;
    private Sequence sequence;
    public int deadShips = 0;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        deadShips = 0;
        sequence = DOTween.Sequence();
        ships = new GameObject[15];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            ships[i] = gameObject.transform.GetChild(i).gameObject;
        }

        
        ships[0].transform.DOLocalMove(new Vector3(-2.5f, -1f, 0f), 1f).SetEase(Ease.OutFlash);
        ships[5].transform.DOLocalMove(new Vector3(-2.5f, 0.25f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(1f);
        ships[10].transform.DOLocalMove(new Vector3(-2.5f, 1.5f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(2f);


        ships[1].transform.DOLocalMove(new Vector3(-1.25f, -1f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(0.1f);
        ships[6].transform.DOLocalMove(new Vector3(-1.25f, 0.25f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(1.1f);
        ships[11].transform.DOLocalMove(new Vector3(-1.25f, 1.5f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(2.1f);

        ships[2].transform.DOLocalMove(new Vector3(0f, -1f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(0.2f);
        ships[7].transform.DOLocalMove(new Vector3(0f, 0.25f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(1.2f);
        ships[12].transform.DOLocalMove(new Vector3(0f, 1.5f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(2.2f);

        ships[3].transform.DOLocalMove(new Vector3(1.25f, -1f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(0.3f);
        ships[8].transform.DOLocalMove(new Vector3(1.25f, 0.25f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(1.3f);
        ships[13].transform.DOLocalMove(new Vector3(1.25f, 1.5f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(2.3f);

        ships[4].transform.DOLocalMove(new Vector3(2.5f, -1f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(0.4f);
        ships[9].transform.DOLocalMove(new Vector3(2.5f, 0.25f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(1.4f);
        ships[14].transform.DOLocalMove(new Vector3(2.5f, 1.5f, 0f), 1f).SetEase(Ease.OutFlash).SetDelay(2.4f);
        
        
        sequence.Append(transform.DOMove(new Vector3(-1f,2.5f,0f), 3f).SetEase(Ease.InOutSine));
        sequence.Append(transform.DOMove(new Vector3(1f, 2.5f, 0f), 3f).SetEase(Ease.InOutSine));
        sequence.SetLoops(-1);
        
    }
    private void Update()
    {
        if(deadShips == 15)
        {
            gameManagerScript.EndWave();
            transform.DOKill(this.transform);
            sequence.Kill();
            Destroy(gameObject);
            
        }
    }
    public void SetDifficulty(int newDifficulty)
    {
        foreach(GameObject ship in ships)
        {
            EnemyShootingScript enemyShootingScript = ship.GetComponent<EnemyShootingScript>();
            enemyShootingScript.SetDifficulty(newDifficulty);
        }
    }
}
