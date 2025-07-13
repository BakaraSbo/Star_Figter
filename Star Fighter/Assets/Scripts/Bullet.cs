using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    void Update()
    {
        transform.position += transform.up*Time.deltaTime*speed;

        if(transform.position.y >= 7 || transform.position.y <= -7 || transform.position.x >= 7 || transform.position.x <= -7)
        {
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
