﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDestroy : MonoBehaviour
{
    /**
     * Start is called before the first frame update
     */
    void Start()
    {
        
    }

    /**
     * Update is called once per frame
     */
    void Update()
    {
        // Destroy the fruit when it is just above the ground.
        if(transform.position.y <= -0.8f)
		{
            Destroy(this.gameObject);
		}
        
    }
}
