using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersMovement : MonoBehaviour
{
    public Vector3 speed;
    void Update()
    {
        this.transform.position += speed * Time.deltaTime;

        if(this.transform.position.y < -11)
        {
            this.transform.position += new Vector3(0,36,0);
        }
    }
}
