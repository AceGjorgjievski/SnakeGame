﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridSpawner;
    public static Food instace;

    private void Awake()
    {
        instace = this;
    }

    private void Start()
    {
        
        this.FoodRandomLocation();
    }


    internal void FoodRandomLocation()
    {
        Bounds bounds = this.gridSpawner.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        this.transform.position = new Vector3(x, y, 0.0f);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.FoodRandomLocation();
        }
    }
}
