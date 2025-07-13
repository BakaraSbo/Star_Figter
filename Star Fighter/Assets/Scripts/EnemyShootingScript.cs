using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyShootingScript : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject PowerUp;

    PlayerScript playerScript;
    GameManagerScript managerScript;
    StandingWaveScrtipt waveScrtipt;
    bool Dead;
    public float firerate, minFirerate, maxFirerate, hp;
    public float[] maxFirerateScaling;
    public int[] hpScaling;

    void Start()
    {
        Dead = false;
        waveScrtipt = gameObject.GetComponentInParent<StandingWaveScrtipt>();
        managerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        minFirerate = 1f;
        maxFirerate = 7f;
        firerate = Random.Range(minFirerate + 2, maxFirerate + 2);
    }
    void Update()
    {
        if (firerate <= 0)
        {
            var bullet = Instantiate(Bullet, transform.position,transform.rotation);
            bullet.transform.Rotate(new Vector3(0, 0, 180));
            bullet.GetComponent<Bullet>().SetSpeed(4);
            firerate = Random.Range(minFirerate, maxFirerate);
        }
        else
            firerate -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_Bullet") && Dead == false)
        {
            if (hp <= 1)
            {
                Dead = true;
                waveScrtipt.deadShips++;
                managerScript.AddScore(100);
                Destroy(collision.gameObject);
                this.transform.DOKill();
                Destroy(gameObject);
                if (Random.Range(0, 100) <= 1 && playerScript.GetWeapon()<5)
                {
                    var s = Instantiate(PowerUp, transform.position, transform.rotation);
                    s.GetComponent<Bullet>().SetSpeed(-3);
                }
            }
            else
            {
                hp--;
                Destroy(collision.gameObject);
            }
                

        }
    }
    public void SetDifficulty(int newDifficulty)
    {
        hp = hpScaling[newDifficulty];
        maxFirerate = maxFirerateScaling[newDifficulty];
    }
}
