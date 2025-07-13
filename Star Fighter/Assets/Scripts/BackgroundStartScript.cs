using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStartScript : MonoBehaviour
{
    public GameObject middleLayer;
    public GameObject topLayer;
    public GameObject ships;
    public GameObject boss;
    int x = 0;
    private void Awake()
    {
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(middleLayer, new Vector3(0, x, 0),this.transform.rotation);
            Instantiate(topLayer, new Vector3(0, x, 0), this.transform.rotation);
            x += 12;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //var shipsItem = Instantiate(ships, new Vector3(1f, 2.5f, 0f), transform.rotation);
            //var bossItem = Instantiate(boss, new Vector3(0f, 2.5f, 0f), transform.rotation);

        }
        

    }
}
