using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    float cooldown, minCooldown, maxCooldown, scale, minPosition, maxPosition, spawningTime, shipSpeed;
    bool spawning;
    public GameObject Ship;
    void Update()
    {
        if (cooldown <= 0 && spawning == true)
        {
            transform.position = new Vector3(Random.Range(minPosition, maxPosition), 7f, transform.position.z);
            scale = Random.Range(1f, 3f);
            var ship = Instantiate(Ship, transform.position, transform.rotation);
            ship.transform.localScale = new Vector3(scale, scale, scale);
            ship.GetComponent<Bullet>().SetSpeed(-shipSpeed);
            cooldown = Random.Range(minCooldown, maxCooldown);
        }
        else
            cooldown -= Time.deltaTime;
        if (spawningTime <= 0)
            spawning = false;
        else
            spawningTime -= Time.deltaTime;
    }
    public void SetParamiters(float maxCool, float minPos, float maxPos, float spawnTime,float newShipSpeed)
    {
        minCooldown = maxCool - 2;
        maxCooldown = maxCool;
        minPosition = minPos;
        maxPosition = maxPos;
        cooldown = Random.Range(minCooldown, maxCooldown);
        spawningTime = spawnTime;
        spawning = true;
        shipSpeed = newShipSpeed;
    }
}
