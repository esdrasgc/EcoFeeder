using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squid : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        speed = 3.0f; 
        transform.LookAt(playerTransform);

    }
}
